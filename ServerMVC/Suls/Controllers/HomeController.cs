namespace Suls.Controllers
{
    using System.Collections.Generic;
    
    using SUS.Http;
    using SUS.MvcFramework;
    using Suls.ViewModels.Problems;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignIn())
            {
                return this.View(new List<HomePageViewModel>() , "IndexLoggedIn");
            }
            return this.View();
        }
    }
}
