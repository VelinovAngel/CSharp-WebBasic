namespace Git.Controllers
{
    using Git.Services;
    using Git.ViewModels.Commits;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;

        public CommitsController(ICommitsService commitsService)
        {
            this.commitsService = commitsService;
        }

        [Authorize]
        public HttpResponse All()
        {
            var model = this.commitsService.GetAll();
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Create(string description, string id, string repoId)
        {
            if (string.IsNullOrWhiteSpace(description) || description.Length < 5)
            {
                return this.Error("Invalid commit!");
            }

            var userId = this.User.Id;
            this.commitsService.CreateCommit(description, id, userId, repoId);
            return this.Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var repoName = this.commitsService.GetById(id);

            var model = new CreateCommitViewModel
            {
                Id = id,
                Name = repoName
            };
            return this.View(model);
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var userId = this.User.Id;
            this.commitsService.RemoveCommit(userId);
            return this.Redirect("/Commits/All");
        }
    }
}
