namespace Andrey.Controllers
{
    using Andrey.Services;
    using MyWebServer.Http;
    using Andrey.ViewModels.Products;
    using MyWebServer.Controllers;

    public class ProductsController : Controller
    {
        private readonly IProducService producService;

        public ProductsController(IProducService producService)
        {
            this.producService = producService;
        }

        [Authorize]
        public HttpResponse Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AllProductInputModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < 4 || model.Name.Length > 20)
            {
                return this.Error("Name must be between 4 and 20 characters!");
            }
            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length < 4 || model.Description.Length > 10)
            {
                return this.Error("Description must be between 4 and 20 characters!");
            }
            this.producService.Add(model);

            return this.Redirect("/");
        }
        [Authorize]
        public HttpResponse Details(int id)
        {
            var product = this.producService.Details(id);
            return this.View(product);
        }

        [Authorize]
        public HttpResponse Delete(int id)
        {
            this.producService.Delete(id);
            return this.Redirect("/");
        }
    }
}
