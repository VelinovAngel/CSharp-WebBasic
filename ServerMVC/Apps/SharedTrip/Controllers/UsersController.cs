using SUS.Http;
using SUS.MvcFramework;
using SharedTrip.ViewModels;
using SharedTrip.Services;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Controllers
{
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

        [HttpPost("/Users/Login")]
        public HttpResponse Login(UsersViewModelLogin model)
        {
            var userId = userService.GetUserId(model.Username, model.Password);
            if (userId == null)
            {
                return this.Error("Invald username or password");
            }
            this.SignIn(userId);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost("/Users/Register")]
        public HttpResponse Register(UsersViewModelRegister model)
        {
            var username = model.Username;
            var email = model.Email;
            var password = model.Password;
            var confirmPassword = model.ConfirmPassword;

            if (string.IsNullOrEmpty(username) || username.Length < 5 || username.Length > 20)
            {
                return this.Error("Invalid Username");
            }
            if (string.IsNullOrEmpty(password) || password.Length < 6 || password.Length > 20)
            {
                return this.Error("Invalid password");
            }
            if (!userService.IsEmailAvailable(email))
            {
                return this.Error("Email already taken");
            }
            if (string.IsNullOrEmpty(email) || !new EmailAddressAttribute().IsValid(email))
            {
                return this.Error("Invalid Email");
            }
            if (!userService.IsUserAvailable(username))
            {
                return this.Error("Username already taken");
            }
            if (password != confirmPassword)
            {
                return this.Error("Invalid password");
            }

            userService.CreateUser(username, email, password);
            return this.Redirect("/");
        }

        public HttpResponse Logout()
        {
            if (!IsUserSignIn())
            {
                this.Error("Only logged-in user can logout!");
            }
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
