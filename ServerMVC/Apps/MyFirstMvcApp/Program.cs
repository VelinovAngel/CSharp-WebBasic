namespace MyFirstMvcApp
{
    using System.Threading.Tasks;

    using SUS.Http;
    using SUS.Http.Contracts;
    using MyFirstMvcApp.Controllers;

    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();
            server.AddRoute("/", new HomeController().Index);
            server.AddRoute("/favicon.ico", new StaticFileController().Favicon);
            server.AddRoute("/about", new HomeController().About);
            server.AddRoute("/users/login", new UsersController().Login);
            server.AddRoute("/users/register", new UsersController().Register);

            /*Set default browser to open localhost*/
            //Process.Start("chrome.exe", "http://localhost/");
            await server.StartAsync(80);
        }







    }
}
