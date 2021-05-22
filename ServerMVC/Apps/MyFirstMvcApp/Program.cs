using SUS.Http;
using SUS.Http.Contracts;
using System;

namespace MyFirstMvcApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IHttpServer server = new HttpServer();     
            server.AddRoute("/", HomePage);
            server.AddRoute("/about", About);
            server.AddRoute("/user/login", Login);

            server.Start(80);
        }

        static HttpResponse HomePage(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        static HttpResponse About(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        static HttpResponse Login(HttpRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
