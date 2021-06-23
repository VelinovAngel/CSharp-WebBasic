namespace Andrey.Controllers
{
    using MyWebServer.Http;
    using Andrey.ViewModels.Users;
    using MyWebServer.Controllers;
    using Andrey.Services;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Login() => this.View();


        [HttpPost]
        public HttpResponse Login(LoginFormModel model)
        {
            var userId = this.userService.GetUserId(model.Username, model.Password);
            if (userId == null)
            {
                return this.Error("Invalid username or password!");
            }
            this.SignIn(userId);
            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegistrationUsersFormModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return this.Error("password and confirm password are not the same!");
            }
            if (string.IsNullOrWhiteSpace(model.Username) || model.Username.Length < 4 || model.Username.Length > 10)
            {
                return this.Error("Username must be between 4 and 10 characters!");
            }
            if (string.IsNullOrWhiteSpace(model.Password) || model.Password.Length < 6 || model.Password.Length > 20)
            {
                return this.Error("Password must be between 6 and 20 characters!");
            }
            if (!this.userService.IsAvailableUsername(model.Username))
            {
                return this.Error($"The username '{model.Username}' already exists");
            }
            if (!this.userService.IsAvailableEmail(model.Email))
            {
                return this.Error($"The email '{model.Email}' already exists");
            }
            this.userService.Register(model);
            return this.View();
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
