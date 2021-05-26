namespace MyFirstMvcApp.Controllers
{
    using SUS.Http;
    using System.IO;

    public class StaticFileController
    {
        public HttpResponse Favicon(HttpRequest request)
        {
            var fileBytes = File.ReadAllBytes("wwwroot/favicon.ico");
            var response = new HttpResponse("image/vnd.microsoft.icon", fileBytes);
            return response;
        }
    }
}
