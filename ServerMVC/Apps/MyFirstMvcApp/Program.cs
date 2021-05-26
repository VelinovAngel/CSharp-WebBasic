namespace MyFirstMvcApp
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using SUS.MvcFramework;
    using MyFirstMvcApp.Controllers;

    class Program
    {
        static async Task Main(string[] args)
        {
            List<Route> routeTable = new List<Route>();
            routeTable.Add(new Route("/", new HomeController().Index));
            routeTable.Add(new Route("/favicon.ico", new StaticFileController().Favicon));
            routeTable.Add(new Route("/Users/Login", new UsersController().Login));
            routeTable.Add(new Route("/Users/Register", new UsersController().Register));
            routeTable.Add(new Route("/Cards/Add", new CardsController().Add));
            routeTable.Add(new Route("/Cards/Collection", new CardsController().All));
            routeTable.Add(new Route("/Cards/All", new CardsController().Collection));

            await Host.CreateHostAsync(routeTable, 80);
        }
    }
}
