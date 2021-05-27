namespace MyFirstMvcApp
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using SUS.Http;
    using SUS.MvcFramework;
    using MyFirstMvcApp.Controllers;

    class Program
    {
        static async Task Main(string[] args)
        {
            List<Route> routeTable = new List<Route>();
            routeTable.Add(new Route("/", new HomeController().Index));
            routeTable.Add(new Route("/users/login", new UsersController().Login));
            routeTable.Add(new Route("/users/register", new UsersController().Register));
            routeTable.Add(new Route("/cards/add", new CardsController().Add));
            routeTable.Add(new Route("/cards/collection", new CardsController().All));
            routeTable.Add(new Route("/cards/all", new CardsController().Collection));

            routeTable.Add(new Route("/favicon.ico", new StaticFileController().Favicon));

            routeTable.Add(new Route("/css/bootstrap.min.css", new StaticFileController().Bootstrap));
            routeTable.Add(new Route("/css/custom.css", new StaticFileController().CustomCss));
            routeTable.Add(new Route("/js/custom.js", new StaticFileController().CustomJs));
            routeTable.Add(new Route("/js/bootstrap.bundle.min.js", new StaticFileController().BootstrapJs));


            await Host.CreateHostAsync(routeTable, 80);
        }
    }
}
