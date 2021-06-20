namespace CarShop.Controllers
{
    using CarShop.Services;
    using CarShop.ViewModels.Users;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            var userId = this.userService.GetUserId(username, password);
            if (userId == null)
            {
                return this.Error("Invalid username or password");
            }

            this.SignIn(userId);
            return this.Redirect("/Cars/All");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUsersViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Username) || model.Username.Length < 4 || model.Username.Length > 20 )
            {
                return this.Error("Invalid username");
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                return this.Error("password and confirm password are not the empty!");
            }
            if (model.Password != model.ConfirmPassword)
            {
                return this.Error("password and confirm password are not the same!");
            }
            if (string.IsNullOrWhiteSpace(model.Password) || model.Password.Length < 5 || model.Password.Length > 20)
            {
                return this.Error("Invalid password");
            }
            if (!this.userService.IsAvailableEmail(model.Email))
            {
                return this.Error("Email address already taken");
            }
            if (!this.userService.IsAvailableUsername(model.Username))
            {
                return this.Error("Username already taken");
            }

            this.userService.Register(model);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
