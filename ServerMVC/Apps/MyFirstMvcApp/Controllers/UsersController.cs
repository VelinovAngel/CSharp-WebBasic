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

        public HttpResponse DoLogin(HttpRequest request)
        {
            // TODO: Read data
            // TODO: Check user
            // TODO: Log user
            // TODO: home page
            return this.Redirect("/");
        }
    }
}
