namespace Andrey.Controllers
{
    using Andrey.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class HomeController : Controller
    {
        private readonly IProducService producService;

        public HomeController(IProducService producService)
        {
            this.producService = producService;
        }

        public HttpResponse IndexSlash()
        {         
            return this.Index();
        }

        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                var allProducts = producService.GetAll();
                return this.View(allProducts, "Home");
            }
            return this.View();
        }
    }
}
