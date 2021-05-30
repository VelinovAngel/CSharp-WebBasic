namespace MyFirstMvcApp.Controllers
{
    using MyFirstMvcApp.ViewModels;
    using SUS.Http;
    using SUS.MvcFramework;
    using System;

    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            var viewModel = new IndexViewModel();
            viewModel.CurrentYear = DateTime.UtcNow.Year;
            viewModel.Message = "Welcome to Battle Cards";
            return this.View(viewModel);
        }

        internal HttpResponse About(HttpRequest arg)
        {
            return this.View();
        }
    }
}
