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

            }
            return this.Redirect("/");
        }
    }
}
