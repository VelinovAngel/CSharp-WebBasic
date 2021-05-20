﻿namespace HttpClientDemo
{
    using System;
    using System.Text;

    using System.Net;
    using System.Net.Http;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    class Program
    {
        const string NewLine = "\r\n";
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);
            tcpListener.Start();

            // deamons - linux // services - windows

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                ProcessClient(client); 
            }
        }

        public static async Task ProcessClient(TcpClient client)
        {
            using (var stream = client.GetStream())
            {
                byte[] buffer = new byte[100000];
                var lenght = await stream.ReadAsync(buffer, 0, buffer.Length);

                var requestString = Encoding.UTF8.GetString(buffer, 0, lenght);
                Console.WriteLine(requestString);

                bool sessionSet = false;
                if (requestString.Contains("sid="))
                {
                    sessionSet = true;
                }

                //how to add many pages??
                string html = $"<h1> Hello from AngelServer  {DateTime.Now}</h1>" +
                    $"<form method=post><input name=username /><input name=password />" +
                    $"<input type=submit /></form>";

                string response = "HTTP/1.1 200 OK"/* 307 Redirect*/ + NewLine +
                    "Server: AngelServer 2021" + NewLine +
                    /*"Location: http://www.google.com" + NewLine +*/
                    "Content-Type: text/html; charset=utf-8" + NewLine +
                    "X-Server-Version: 1.0" + NewLine +
                    "Content-Lenght: " + html.Length + NewLine +
                    NewLine +
                    html;

                byte[] responseByte = Encoding.UTF8.GetBytes(response);
                await stream.WriteAsync(responseByte);

                Console.WriteLine(new string('=', 70));
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
