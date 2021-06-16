namespace MyWebServer.App.Controllers 
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    public class UsersController : Controller
    {
        public HttpResponse Login()
        {
            return this.View();
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        public HttpResponse Logout()
        {
            return this.Redirect("/");
        }
    }
}
