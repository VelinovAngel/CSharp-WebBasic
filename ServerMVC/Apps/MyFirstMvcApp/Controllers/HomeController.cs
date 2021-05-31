namespace MyFirstMvcApp.Controllers
{
    using System;

    using SUS.Http;
    using SUS.MvcFramework;
    using MyFirstMvcApp.ViewModels;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.CurrentYear = DateTime.UtcNow.Year;
            viewModel.Message = "Welcome to Battle Cards";
            return this.View(viewModel);
        }

        public HttpResponse About()
        {
            return this.View();
        }
    }
}
