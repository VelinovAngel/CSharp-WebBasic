﻿namespace MyFirstMvcApp.Controllers
{
    using SUS.Http;
    using SUS.MvcFramework;

    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            return this.View();
        }

        //public HttpResponse About(HttpRequest request)
        //{
        //    var responseHtml = "<h1>About...</h1>";
        //    var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
        //    var response = new HttpResponse("text/html", responseBodyBytes);

        //    return response;
        //}
    }
}
