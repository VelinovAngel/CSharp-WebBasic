namespace IRunes.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class HomeController : Controller
    {
        public HttpResponse IndexSlash() => this.View();


        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.View("Home");
            }
            return this.View();
        }
    }
}
