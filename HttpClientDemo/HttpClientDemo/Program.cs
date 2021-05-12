using System;
using System.Text;

using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);
            tcpListener.Start();

            // deamon // service 

            while (true)
            {  
                var client = tcpListener.AcceptTcpClient();
                
            }
        }

        public static async Task ReadData()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string url = "https://softuni.bg";
            HttpClient httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            Console.WriteLine(html);
        }
    }
}
