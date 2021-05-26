namespace MyFirstMvcApp.Controllers
{
    using SUS.Http;
    using System.Linq;
    using System.Text;


    public class UsersController
    {
        HttpResponse Login(HttpRequest request)
        {
            var responseHtml = "<h1>Login!</h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        HttpResponse Register(HttpRequest request)
        {
            var responseHtml = "<h1>Register!</h1>" + request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
