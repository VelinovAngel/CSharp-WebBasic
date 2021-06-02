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
            if (this.IsUserSignIn())
            {
                return this.Redirect("/Cards/All");
            }
            else
            {
                return this.View();
            }
        }

        public HttpResponse About()
        {
            this.Request.Session["about"] = "yes";
            return this.View();
        }
    }
}
