namespace MyFirstMvcApp.Controllers
{
    using MyFirstMvcApp.ViewModels;
    using SUS.Http;
    using SUS.MvcFramework;
    using System;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index(HttpRequest request)
        {
            var viewModel = new IndexViewModel();
            viewModel.CurrentYear = DateTime.UtcNow.Year;
            viewModel.Message = "Welcome to Battle Cards";
            return this.View(viewModel);
        }

        public HttpResponse About(HttpRequest arg)
        {
            return this.View();
        }
    }
}
