using System;

namespace MyFirstMvcApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new HttpServer();
           
            server.AddRoute("/", HomePage);

            server.AddRoute("/about", About);

            server.AddRoute("/user/login", Login);

            server.Start(80);
        }

        static HttpResponse HomePage(HttpRequest request)
        {

        }

        static HttpResponse About(HttpRequest request)
        {

        }

        static HttpResponse Login(HttpRequest request)
        {

        }
    }
}
