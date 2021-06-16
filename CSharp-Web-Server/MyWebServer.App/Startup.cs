using System.Threading.Tasks;
using MyWebServer.App.Controllers;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;

namespace MyWebServer.App
{
    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers()
                .MapGet<UsersController>("/Users/Login", c=>c.Login()))
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>())
                .Start();
    }
}
