﻿namespace SUS.MvcFramework
{
    using System.Text;
    using System.Runtime.CompilerServices;

    using SUS.Http;

    public abstract class Controller
    {
        public HttpResponse View([CallerMemberName] string viewPath = null)
        {
            var layout = System.IO.File.ReadAllText("Views/Shared/_Layout.html");

            var viewContent = System.IO.File.ReadAllText("Views/" + this.GetType().Name.Replace("Controller", string.Empty) + "/" + viewPath + ".html");
            var responseHtml = viewContent.Replace("@RenderBody()", viewContent);

            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        public HttpResponse File(string filePath, string contentType)
        {
            var fileBytes = System.IO.File.ReadAllBytes("wwwroot/favicon.ico");
            var response = new HttpResponse("image/vnd.microsoft.icon", fileBytes);

            return response;
        }
    }
}
