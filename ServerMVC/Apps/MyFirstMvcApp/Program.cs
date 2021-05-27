namespace MyFirstMvcApp
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using SUS.Http;
    using SUS.MvcFramework;
    using MyFirstMvcApp.Controllers;
    using SUS.Http.Enums;

    class Program
    {
        static async Task Main(string[] args)
        {
            List<Route> routeTable = new List<Route>();
            routeTable.Add(new Route("/", HttpMethod.Get, new HomeController().Index));
            routeTable.Add(new Route("/users/login", HttpMethod.Get, new UsersController().Login));
            routeTable.Add(new Route("/users/login", HttpMethod.Post, new UsersController().DoLogin));
            routeTable.Add(new Route("/users/register", HttpMethod.Get, new UsersController().Register));
            routeTable.Add(new Route("/cards/add", HttpMethod.Get, new CardsController().Add));
            routeTable.Add(new Route("/cards/collection", HttpMethod.Get, new CardsController().All));
            routeTable.Add(new Route("/cards/all", HttpMethod.Get, new CardsController().Collection));

            routeTable.Add(new Route("/favicon.ico", HttpMethod.Get, new StaticFileController().Favicon));

            routeTable.Add(new Route("/css/bootstrap.min.css", HttpMethod.Get, new StaticFileController().Bootstrap));
            routeTable.Add(new Route("/css/custom.css", HttpMethod.Get, new StaticFileController().CustomCss));
            routeTable.Add(new Route("/js/custom.js", HttpMethod.Get, new StaticFileController().CustomJs));
            routeTable.Add(new Route("/js/bootstrap.bundle.min.js", HttpMethod.Get, new StaticFileController().BootstrapJs));


            await Host.CreateHostAsync(routeTable, 80);
        }
    }
}
