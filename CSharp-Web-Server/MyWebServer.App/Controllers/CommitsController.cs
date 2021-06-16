namespace MyWebServer.App.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class CommitsController : Controller
    {
        public HttpResponse All()
        {
            return this.View();
        }

        public HttpResponse Create()
        {
            return this.View();
        }
    }
}
