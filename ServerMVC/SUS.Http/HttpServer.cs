namespace SUS.Http
{
    using System;
    using System.Net;
    using System.Text;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using SUS.Http.Contracts;
    using SUS.Http.GlobalConstans;
    using System.Linq;

    public class HttpServer : IHttpServer
    {
        IDictionary<string, Func<HttpRequest, HttpResponse>>
            routeTable = new Dictionary<string, Func<HttpRequest, HttpResponse>>();

        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action)
        {
            if (routeTable.ContainsKey(path))
            {
                routeTable[path] = action;
            }
            else
            {
                routeTable.Add(path, action);
            }
        }

        public async Task StartAsync(int port)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port);
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                ProcessClientAsync(tcpClient);
            }
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            using (NetworkStream stream = tcpClient.GetStream())
            {
                //TODO: research if there is faster data structure for array of bytes?
                List<byte> data = new List<byte>();
                int position = 0;
                byte[] buffer = new byte[HttpConstans.BufferSize];
                while (true)
                {
                    int count = await stream.ReadAsync(buffer, position, buffer.Length);
                    position += count;

                    if (count < buffer.Length)
                    {
                        var partialBuffer = new byte[count];
                        Array.Copy(buffer, partialBuffer, count);
                        data.AddRange(partialBuffer);
                        break;
                    }
                    else
                    {
                        data.AddRange(buffer);
                    }
                }

                // byte[] => string (text)
                var requestAsString = Encoding.UTF8.GetString(data.ToArray());

                var request = new HttpRequest(requestAsString);

                Console.WriteLine(requestAsString);
                //TODO: extract info requestAsString

                var responseHtml = "<h1>Wellcome</h1>" + request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;
                var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

                var responseHttp = "HTTP/1.1 200 OK" + HttpConstans.NewLine +
                    "Server: SoftUniServer 1.0" + HttpConstans.NewLine +
                    "Content-Type: text/html" + HttpConstans.NewLine +
                    "Content-Lenght: " + responseBodyBytes.Length + HttpConstans.NewLine + HttpConstans.NewLine;

                var responseHeaderBytes = Encoding.UTF8.GetBytes(responseHttp);

                await stream.WriteAsync(responseHeaderBytes);
                await stream.WriteAsync(responseBodyBytes);
            }

            tcpClient.Close();
        }
    }
}
