namespace MyWebServer.App.Controllers
{
    using MyWebServer.App.Services;
    using MyWebServer.App.ViewModels.Repositories;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

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

        public HttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(RegistrationViewModel model)
        {
            var userId = this.User.Id;

            if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < 3 || model.Name.Length > 10)
            {
                return this.Error("Repository name must be between 3 and 10 characters!");
            }

            repositoriesService.CreateRepository(model, userId);

            return this.View();
        }
    }
}
