﻿namespace SUS.Http
{
    using System;
    using System.Net;
    using System.Linq;
    using System.Text;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using SUS.Http.Contracts;
    using SUS.Http.GlobalConstans;


    public class HttpServer : IHttpServer
    {
        List<Route> routeTable;

        public HttpServer(List<Route> routeTable)
        {
            this.routeTable = routeTable;
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
            try
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

                    Console.WriteLine($"{request.Method} {request.Path} => {request.Headers.Count} headers");
                    //TODO: extract info requestAsString

                    HttpResponse response;
                    var route = this.routeTable.FirstOrDefault(x => string.Compare(x.Path, request.Path, true) == 0 
                    && x.Method == request.Method);

                    if (route != null)
                    {
                        response = route.Action(request);
                    }
                    else
                    {
                        //Not found 404
                        response = new HttpResponse("text/html", new byte[0], (Enums.HttpStatusCode)HttpStatusCode.NotFound);
                    }

                    response.Headers.Add(new Header("Server", "SoftUniServer 1.0"));
                    response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString())
                    { HttpOnly = true, MaxAge = 60 * 24 * 60 * 60 });
                    var responseHeaderBytes = Encoding.UTF8.GetBytes(response.ToString());
                    await stream.WriteAsync(responseHeaderBytes, 0, responseHeaderBytes.Length);
                    await stream.WriteAsync(response.Body, 0, response.Body.Length);
                }

                tcpClient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
