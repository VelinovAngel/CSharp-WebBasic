namespace MyFirstMvcApp.Controllers
{
    using MyFirstMvcApp.ViewModels;
    using SUS.Http;
    using SUS.MvcFramework;

    public class CardsController : Controller
    {
        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost("/Cards/Add")]
        public HttpResponse DoAdd()
        {
            var request = this.Request;
            var viewModel = new DoAddViewModel()
            {
                Attack = int.Parse(this.Request.FromData["attack"]),
                Health = int.Parse(this.Request.FromData["health"]),
            };
            return this.View(viewModel);
        }

        public HttpResponse All()
        {
            return this.View();
        }

        public HttpResponse Collection()
        {
            return this.View();
        }
    }
}
