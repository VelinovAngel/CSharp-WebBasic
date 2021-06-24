namespace IRunes
{
    using IRunes.Data;
    using MyWebServer;
    using IRunes.Services;
    using System.Threading.Tasks;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                .MapStaticFiles()
                .MapControllers())
            .WithServices(services => services
                .Add<IViewEngine, CompilationViewEngine>()
                .Add<IUserService, UserService>()
                .Add<IAlbumService, AlbumService>()
                .Add<ITrackService, TrackService>()
                .Add<AppDbContext>())
            .WithConfiguration<AppDbContext>(x=>x.Database.Migrate())
            .Start();
    }
}
