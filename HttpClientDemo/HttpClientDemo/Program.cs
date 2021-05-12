﻿using System;
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
                const string NewLine = "\r\n";
                var client = tcpListener.AcceptTcpClient();
                using (var stream = client.GetStream())
                {

                    byte[] buffer = new byte[100000];
                    var lenght = stream.Read(buffer, 0, buffer.Length);

                    var requestString = Encoding.UTF8.GetString(buffer, 0, lenght);
                    Console.WriteLine(requestString);


                    string html = $"<h1> Hello from AngelServer  {DateTime.Now}</h1>";

                    string response = "HTTP/1.1 200 OK"/* 307 Redirect*/ + NewLine +
                        "Server: AngelServer 2021" + NewLine +
                        /*"Location: http://www.google.com" + NewLine +*/
                        "Content-Type: text/html; charset=utf-8" + NewLine +
                        "Content-Lenght: " + html.Length + NewLine +
                        NewLine +
                        html;

                    byte[] responseByte = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseByte);

                    Console.WriteLine(new string('=', 70));
                }
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
