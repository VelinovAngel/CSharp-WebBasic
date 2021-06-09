namespace Suls.Controllers
{
    using SUS.Http;
    using SUS.MvcFramework;

    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            return this.View();
        }
    }
}
