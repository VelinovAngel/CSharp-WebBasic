namespace IRunes.Controllers
{
    using IRunes.Services;
    using IRunes.ViewModels.Users;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Text.RegularExpressions;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Register() => this.View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }
            if (string.IsNullOrWhiteSpace(model.Username) || model.Username.Length < 4 || model.Username.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }
            if (string.IsNullOrWhiteSpace(model.Email))
            {
                return this.Redirect("/Users/Register");
            }
            if (!Regex.IsMatch(model.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                return this.Redirect("/Users/Register");
            }
            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }
            if (!userService.IsAvailableEmail(model.Email))
            {
                return this.Redirect("/Users/Register");
            }
            if (!userService.IsAvailableUsername(model.Email))
            {
                return this.Redirect("/Users/Register");
            }
            this.userService.Register(model);
            return this.Redirect("/");
        }

        public HttpResponse Login() => this.View();

        [HttpPost]
        public HttpResponse Login(LoginViewModel model)
        {
            var userId = userService.GetUseId(model.Username, model.Password);
            this.SignIn(userId);
            return this.Redirect("/");
        }

        public HttpResponse Logout()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Error("Only logged in user can logout!");
            }
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
