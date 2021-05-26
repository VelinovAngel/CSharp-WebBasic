namespace MyFirstMvcApp.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Text;

    using SUS.Http;
    using SUS.MvcFramework;


    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            var responseHtml = "<h1>Login!</h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        public HttpResponse Register(HttpRequest request)
        {
            var responseHtml = File.ReadAllText("Views/Users/Register.html");
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
