namespace BattleCards.Controllers
{
    using SUS.Http;
    using SUS.MvcFramework;

    using BattleCards.Services;
    using System.Text.RegularExpressions;
    using System.ComponentModel.DataAnnotations;

    public class UsersController : Controller
    {
        private UsersService userService;

        public UsersController()
        {
            this.userService = new UsersService();
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost("Users/Login")]
        public HttpResponse DoLogin()
        {
            var username = this.Request.FormData["username"];
            var password = this.Request.FormData["password"];
            var userId = this.userService.GetUserId(username, password);

            if (userId == null)
            {
                return this.Error("Invalid username or password");
            }

            this.SignIn(userId);
            return this.Successful("Successful login");
        }

        [HttpPost]
        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost("/Users/Register")]
        public HttpResponse DoRegister()
        {
            var username = this.Request.FormData["username"];
            var email = this.Request.FormData["email"];
            var password = this.Request.FormData["password"];
            var confirmPassword = this.Request.FormData["confirmPassword"];

            if (username == null || username.Length < 5 || username.Length > 20)
            {
                return this.Error("Invalid username. The username should be between 5 and 20 characters");
            }

            if (!Regex.IsMatch(username, @"[a-zA-Z0-9\.]+"))
            {
                return this.Error("Invalid username");
            }

            if (string.IsNullOrWhiteSpace(email) || !new EmailAddressAttribute().IsValid(email))
            {
                return this.Error("Invalid email address.");
            }

            if (password == null || password.Length < 6 || password.Length > 20)
            {
                return this.Error("Invalid password. The password should be between 5 and 20 characters");
            }

            if (password != confirmPassword)
            {
                return this.Error("Passwords should be the same!");
            }

            if (!this.userService.IsUsernameAvailable(username))
            {
                return this.Error("User already taken.");
            }

            if (!this.userService.IsEmailAvailable(email))
            {
                return this.Error("Email already taken.");
            }

            var userId = this.userService.CreateUser(username, email, password);

            this.Successful("Successful registration :)");
            return this.Redirect("/Users/Login");
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
