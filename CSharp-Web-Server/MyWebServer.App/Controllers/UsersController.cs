namespace MyWebServer.App.Controllers 
{
    using MyWebServer.App.Services;
    using MyWebServer.App.ViewModels.Users;
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
        public HttpResponse Login(string username , string password)
        {
            var userId = this.userService.GetUserId(username, password);
            if (userId == null)
            {
                return this.Error("Invalid username or password!");
            }

            this.SignIn(userId);

            return this.View("/Repositories/All");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return this.Error("Password and confirmpassword can not are different!");
            }
            if (!this.userService.IsAvailableEmail(model.Email))
            {
                return this.Error("Already email taken");
            }
            if (!this.userService.IsAvalaibleUser(model.Username))
            {
                return this.Error("Already username taken");
            }
            if (string.IsNullOrWhiteSpace(model.Username) || model.Username.Length < 5 || model.Username.Length > 20)
            {
                return this.Error("Invalid username! The username must be between 5 and 20 characters");
            }
            if (string.IsNullOrWhiteSpace(model.Password) || model.Password.Length < 6 || model.Password.Length > 20)
            {
                return this.Error("Invalid password! The username must be between 6 and 20 characters.");
            }

            this.userService.Register(model);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            return this.Redirect("/");
        }
    }
}
