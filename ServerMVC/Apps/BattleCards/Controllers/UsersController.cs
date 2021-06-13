namespace BattleCards.Controllers
{
    using System.Text.RegularExpressions;
    using System.ComponentModel.DataAnnotations;

    using SUS.Http;
    using SUS.MvcFramework;

    using BattleCards.Services;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
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
        public HttpResponse Login(string username, string password)
        {
            var userId = this.usersService.GetUserId(username, password);

            if (userId == null)
            {
                return this.Error("Invalid username or password");
            }

            this.SignIn(userId);
            return this.Successful("Successful login");
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
        public HttpResponse Register(string username , string email, string password, string confirmPassword)
        {
            if (username == null || username.Length < 5 || username.Length > 20)
            {
                return this.Error("Invalid username. The username should be between 6 and 20 characters");
            }

            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9\.]+$"))
            {
                return this.Error("Invalid username");
            }

            if (string.IsNullOrWhiteSpace(email) || !new EmailAddressAttribute().IsValid(email))
            {
                return this.Error("Invalid email address.");
            }

            if (password == null || password.Length < 6 || password.Length > 20)
            {
                return this.Error("Invalid password. The password should be between 6 and 20 characters");
            }

            if (password != confirmPassword)
            {
                return this.Error("Passwords should be the same!");
            }

            if (!this.usersService.IsUsernameAvailable(username))
            {
                return this.Error("User already taken.");
            }

            if (!this.usersService.IsEmailAvailable(email))
            {
                return this.Error("Email already taken.");
            }

            var userId = this.usersService.CreateUser(username, email, password);

            return this.Successful("Successful registration :)");      
        }


        public HttpResponse Logout()
        {
            if (!this.IsUserSignIn())
            {
                return this.Error("Only logged-in users can logout!");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
