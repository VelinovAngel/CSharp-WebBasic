namespace IRunes.Controllers
{
    using IRunes.Services;
    using IRunes.ViewModels.Users;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse IndexSlash() => this.View();


        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                var user = userService.GerUserName(this.User.Id);
                return this.View(user, "Home");
            }
            return this.View();
        }
    }
}
