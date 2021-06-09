namespace Suls.Controllers
{
    using SUS.Http;
    using SUS.MvcFramework;
    using Suls.ViewModels.Users;
 
    public class UsersController : Controller
    {
        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost("Users/Login")]
        public HttpResponse Login(string username , string password)
        {
            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        public HttpResponse Register(UserViewModel model)
        {
            //TODO all logical
            return this.Redirect("/Users/Login");
        }
    }
}
