namespace MyFirstMvcApp
{
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using SUS.Http;
    using SUS.Http.Contracts;

    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();
            server.AddRoute("/", HomePage);
            server.AddRoute("/favicon.ico", Favicon);
            server.AddRoute("/about", About);
            server.AddRoute("/login", Login);

            /*Set default browser to open localhost*/
            //Process.Start("chrome.exe", "http://localhost/");
            await server.StartAsync(80);
        }

        static HttpResponse HomePage(HttpRequest request)
        {
            var responseHtml = "<h1>Wellcome!</h1>" + request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        static HttpResponse Favicon(HttpRequest request)
        {
            var fileBytes = File.ReadAllBytes("wwwroot/favicon.ico");
            var response = new HttpResponse("image/vnd.microsoft.icon", fileBytes);
            return response;
        }

        static HttpResponse About(HttpRequest request)
        {
            var responseHtml = "<h1>About...</h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        static HttpResponse Login(HttpRequest request)
        {
            var responseHtml = "<h1>Login!</h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
