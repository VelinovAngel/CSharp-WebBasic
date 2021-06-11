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
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, int points)
        {
            if (name.Length < 5 || name.Length > 20 || string.IsNullOrEmpty(name))
            {
                this.Error("Invalid problem name!");
            }
            if (points < 50 || points > 300)
            {
                this.Error("Invalid points!");
            }
            problemService.CreateProblem(name, points);
            return this.View();
        }
    }
}
