namespace SharedTrip.Controllers
{
    using MyWebServer.Http;
    using MyWebServer.Controllers;

    using SharedTrip.Services;
    using SharedTrip.ViewModels.Users;

    using System.ComponentModel.DataAnnotations;

    public class UsersController : Controller
    {
        private const string  RedirectUserRegister = "/Users/Register";
        private const string  RedirectUserLogin = "/Users/Login";

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
        public HttpResponse Login(LoginUserFormModel model)
        {
            var userId = userService.GetUserId(model.Username, model.Password);
            if (userId == null)
            {
                return this.Redirect(RedirectUserLogin);
                //return this.Error("Invald username or password");
            }
            this.SignIn(userId);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var username = model.Username;
            var email = model.Email;
            var password = model.Password;
            var confirmPassword = model.ConfirmPassword;

            if (string.IsNullOrEmpty(username) || username.Length < 5 || username.Length > 20)
            {
                return this.Redirect(RedirectUserRegister);
                //return this.Error("Invalid Username");
            }
            if (string.IsNullOrEmpty(password) || password.Length < 6 || password.Length > 20)
            {
                return this.Redirect(RedirectUserRegister);
                //return this.Error("Invalid password");
            }
            if (password != confirmPassword)
            {
                return this.Redirect(RedirectUserRegister);
                //return this.Error("Invalid password");
            }
            if (!userService.IsEmailAvailable(email))
            {
                return this.Redirect(RedirectUserRegister);
                //return this.Error("Email already taken");
            }
            if (string.IsNullOrEmpty(email) || !new EmailAddressAttribute().IsValid(email))
            {
                return this.Redirect(RedirectUserRegister);
                //return this.Error("Invalid Email");
            }
            if (!userService.IsUserAvailable(username))
            {
                return this.Redirect(RedirectUserRegister);
                //return this.Error("Username already taken");
            }

           userService.CreateUser(username, email, password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.User.IsAuthenticated)
            {
                this.Error("Only logged-in user can logout!");
            }
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
