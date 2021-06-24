namespace IRunes.Controllers
{
    using IRunes.Services;
    using IRunes.ViewModels;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

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
            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }
            this.userService.Register(model);
            return this.Redirect("/");
        }

        public HttpResponse Login() => this.View();


    }
}
