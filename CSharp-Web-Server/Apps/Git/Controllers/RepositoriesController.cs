namespace Git.Controllers
{
    using MyWebServer.Http;
    using MyWebServer.Controllers;
    using Git.Services;
    using Git.ViewModels.Repositories;

    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            var model = this.repositoriesService.GetAllRepository();

            return this.View(model);
        }

        [Authorize]
        public HttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Create(RegistrationViewModel model)
        {
            var userId = this.User.Id;

            if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < 3 || model.Name.Length > 10)
            {
                return this.Error("Repository name must be between 3 and 10 characters!");
            }

            repositoriesService.CreateRepository(model, userId);

            return this.Redirect("/Repositories/All");
        }
    }
}
