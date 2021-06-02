namespace BattleCards.Controllers
{
    using System;

    using SUS.Http;
    using SUS.MvcFramework;
    using BattleCards.ViewModels;
    using SUS.Http.GlobalConstans;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.CurrentYear = DateTime.UtcNow.Year;
            viewModel.Message = "Welcome to Battle Cards";
            if (this.Request.Session.ContainsKey("about"))
            {
                viewModel.Message += HttpConstans.NewLine + "YOU WERE ON THE ABOUT PAGE!";
            }
            return this.View(viewModel);
        }

        public HttpResponse About()
        {
            this.Request.Session["about"] = "yes";
            return this.View();
        }
    }
}
