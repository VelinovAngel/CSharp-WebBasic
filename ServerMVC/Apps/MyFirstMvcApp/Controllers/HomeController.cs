namespace MyFirstMvcApp.Controllers
{
    using System.Linq;
    using System.Text;

    using SUS.Http;
    using SUS.MvcFramework;

    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            var responseHtml = "<h1>Wellcome!</h1>" + request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        public HttpResponse About(HttpRequest request)
        {
            var responseHtml = "<h1>About...</h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
