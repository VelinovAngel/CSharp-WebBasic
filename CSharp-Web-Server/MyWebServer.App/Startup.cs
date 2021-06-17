namespace MyWebServer.App
{
    using System.Threading.Tasks;
    using MyWebServer.App.Data;
    using MyWebServer.Controllers;
    using Microsoft.EntityFrameworkCore;

    public class Startup
    {
        public static async Task Main()
           => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                .Add<ApplicationDbContext>())
                .WithConfiguration<ApplicationDbContext>(c=>c.Database.Migrate())
                .Start();
    }
}
