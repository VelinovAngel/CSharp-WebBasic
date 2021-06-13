namespace Suls.Controllers
{
    using Suls.Services;

    using SUS.Http;
    using SUS.MvcFramework;

    public class ProblemsController : Controller
    {
        private readonly IProblemService problemService;

        public ProblemsController(IProblemService problemService)
        {
            this.problemService = problemService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Register");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, int points)
        {
            if (name.Length < 5 || name.Length > 20 || string.IsNullOrEmpty(name))
            {
                return this.Redirect("/Problems/Create");
            }
            if (string.IsNullOrEmpty(points.ToString()) || points < 50 || points > 300)
            {
                return this.Redirect("/Problems/Create");
            }
            problemService.CreateProblem(name, points);

            return this.Redirect("/");
        }

        
        public HttpResponse Details(string id)
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Register");
            }
            var viewModel = this.problemService.GetById(id);
            
            return this.View(viewModel);
        }
    }
}
