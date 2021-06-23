namespace Andrey
{
    using Andrey.Data;
    using MyWebServer;
    using System.Threading.Tasks;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using Microsoft.EntityFrameworkCore;
    using Andrey.Services;

    public class StartUp
    {
        static async Task Main()
            => await HttpServer
                .WithRoutes(route => route
                    .MapStaticFiles()
                    .MapControllers())
                        .WithServices(service => service
                            .Add<IViewEngine, CompilationViewEngine>()
                            .Add<IUserService, UserService>()
                            .Add<IProducService,ProducService>()
                            .Add<AppDbContext>())
                    .WithConfiguration<AppDbContext>(a=>a.Database.Migrate())
                .Start();
    }
}
