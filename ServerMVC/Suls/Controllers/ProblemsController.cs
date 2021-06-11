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
          
        }
    }
}
