namespace SUS.MvcFramework
{
    using System.IO;
    using System.Text;

    using SUS.Http;

    public abstract class Controller
    {
        public HttpResponse View(string viewPath)
        {
            var responseHtml = File.ReadAllText(viewPath);
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
