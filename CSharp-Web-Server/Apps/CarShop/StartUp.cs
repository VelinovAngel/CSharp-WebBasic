namespace CarShop
{
    using MyWebServer;
    using CarShop.Data;
    using System.Threading.Tasks;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using Microsoft.EntityFrameworkCore;
    using CarShop.Services;

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
                    .Add<IIssueService, IssueService>()
                    .Add<ICarService, CarService>()
                    .Add<AppDbContext>())
                .WithConfiguration<AppDbContext>(x => x.Database.Migrate())
            .Start();
    }
}
