namespace Andrey
{
    using MyWebServer;
    using System.Threading.Tasks;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;

    public class StartUp
    {
        static async Task Main()
            => await HttpServer
                .WithRoutes(route => route
                    .MapStaticFiles()
                    .MapControllers())
                        .WithServices(service => service
                            .Add<IViewEngine, CompilationViewEngine>())
                .Start();
    }
}
