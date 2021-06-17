namespace MyWebServer.App
{
    using System.Threading.Tasks;
    using MyWebServer.App.Data;
    using MyWebServer.Controllers;
    using Microsoft.EntityFrameworkCore;
    using MyWebServer.Results.Views;
    using MyWebServer.App.Services;

    public class Startup
    {
        public static async Task Main()
           => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                .Add<IViewEngine, CompilationViewEngine>()
                .Add<IUserService,UserService>()
                .Add<ApplicationDbContext>())
                .WithConfiguration<ApplicationDbContext>(c=>c.Database.Migrate())
                .Start();
    }
}
