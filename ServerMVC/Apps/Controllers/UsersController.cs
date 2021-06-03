namespace BattleCards.Controllers
{

    using SUS.Http;
    using SUS.MvcFramework;

    public class UsersController : Controller
    {
        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost("Users/Login")]
        public HttpResponse DoLogin()
        {
            // TODO: Read data
            // TODO: Check user
            // TODO: Log user
            // TODO: home page
            return this.Redirect("/");
        }

        [HttpPost]
        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost("/Users/Register")]
        public HttpResponse DoRegister()
        {
            return this.Redirect("/");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignIn())
            {
                return this.Error("Only logged-in users ca logout!");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
