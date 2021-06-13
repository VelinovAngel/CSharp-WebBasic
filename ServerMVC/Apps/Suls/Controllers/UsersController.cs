namespace Suls.Controllers
{
    using System.ComponentModel.DataAnnotations;

    using SUS.Http;
    using SUS.MvcFramework;

    using Suls.Services;
    using Suls.ViewModels.Users;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        public HttpResponse Login()
        {
            if (this.IsUserSignIn())
            {
                return this.Redirect("/");
            }
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

            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UserViewModel model)
        {
            if (string.IsNullOrEmpty(model.Username) || model.Username.Length < 5 || model.Username.Length > 20)
            {
                this.Error("The username should be between 5 and 20 characters!");
            }
            if (string.IsNullOrEmpty(model.Email) || !new EmailAddressAttribute().IsValid(model.Email))
            {
                this.Error("The email address should be valid!");
            }
            if (string.IsNullOrEmpty(model.Password) || model.Password.Length > 6 || model.Password.Length < 20)
            {
                this.Error("Invalid password");
            }
            if (model.Password != model.ConfirmPassword)
            {
                this.Error("Invalid password!");
            }
            if (!userService.IsEmailAvailable(model.Email))
            {
                this.Error("Email already taken");
            }
            if (!userService.IsUserAvailable(model.Username))
            {
                this.Error("Username already taken");
            }

            userService.CreateUser(model.Username, model.Email, model.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignIn())
            {
                this.Error("Only logged-in user can logout!");

            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
