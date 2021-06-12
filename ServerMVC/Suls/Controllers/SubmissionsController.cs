namespace Suls.Controllers
{
    using Suls.Services;
    using Suls.ViewModels.Submissions;
    using SUS.Http;
    using SUS.MvcFramework;
   
    public class SubmissionsController : Controller
    {
        private readonly IProblemService problemService;
        private readonly ISubmissionService submissionService;

        public SubmissionsController(IProblemService problemService, ISubmissionService submissionService)
        {
            this.problemService = problemService;
            this.submissionService = submissionService;
        }
        public HttpResponse Create(string id)
        {
            var viewModel = new CreateViewModel
            {
                ProblemId = id,
                Name = problemService.GetNameById(id),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId , string code)
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(code) || code.Length <30 || code.Length >800)
            {
                return this.Error("Invalid text");
            }
            this.submissionService.Create(problemId, userId, code);
            return this.Redirect("/");
        }
    }
}
