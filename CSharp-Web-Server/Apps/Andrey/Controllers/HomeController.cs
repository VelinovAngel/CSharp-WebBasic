namespace Andrey.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Home");
            }
            return this.View();
        }

        public HttpResponse Home()
        {
            return this.View();
        }
    }
}
