namespace MyWebServer.App
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MyWebServer.App.Data;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;

    public class Startup
    {
        public static async Task Main()
        {
            new ApplicationDbContext().Database.Migrate();

            await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                .Add<ApplicationDbContext>())
                .Start();
        }
    }
}
