namespace MyFirstMvcApp.Controllers
{
    using SUS.Http;
    using SUS.MvcFramework;


    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return this.View();
        }

        public HttpResponse Register(HttpRequest request)
        {
            return this.View();
        }
    }
}
