namespace Suls.Controllers
{
    using System.Collections.Generic;

    using SUS.Http;
    using SUS.MvcFramework;
    using Suls.ViewModels.Problems;
    using Suls.Services;

    public class HomeController : Controller
    {
        private readonly IProblemService problemService;

        public HomeController(IProblemService problemService)
        {
            this.problemService = problemService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignIn())
            {
                return this.View(problemService.GetAll(), "IndexLoggedIn");
            }
            return this.View();
        }
    }
}
