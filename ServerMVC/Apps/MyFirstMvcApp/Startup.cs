namespace MyFirstMvcApp
{
    using MyFirstMvcApp.Controllers;
    using SUS.Http;
    using SUS.Http.Enums;
    using SUS.MvcFramework.Contracts;
    using System.Collections.Generic;


    public class Startup : IMvcApplication
    {
        public void ConfigureServices()
        {            
        }

        public void Configure(List<Route> routeTable)
        {
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
        }
    }
}