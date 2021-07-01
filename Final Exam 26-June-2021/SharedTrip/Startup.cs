namespace SharedTrip
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;

    using SharedTrip.Data;
    using SharedTrip.Services;

    public class Startup
    {
        /*
         1) Used Port 80 instead of 5000
         2) I made all the view errors for validation and left them all in a commented row, if you want to use they :)
        */
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IUserService, UserService>()
                    .Add<ITripService, TripService>()
                    .Add<ApplicationDbContext>())
                .WithConfiguration<ApplicationDbContext>(x=>x.Database.Migrate())
                .Start();
    }
}
