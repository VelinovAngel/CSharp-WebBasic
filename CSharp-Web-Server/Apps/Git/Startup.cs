namespace Git
{
    using Git.Data;
    using MyWebServer;
    using Git.Services;
    using System.Threading.Tasks;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using Microsoft.EntityFrameworkCore;

    public class Startup
    {
        public static async Task Main()
           => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                .Add<IViewEngine, CompilationViewEngine>()
                .Add<IUserService, UserService>()
                .Add<IRepositoriesService, RepositoriesService>()
                .Add<ICommitsService, CommitsService>()
                .Add<ApplicationDbContext>())
                .WithConfiguration<ApplicationDbContext>(c => c.Database.Migrate())
                .Start();
    }
}
