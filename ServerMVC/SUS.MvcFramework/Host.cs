namespace SUS.MvcFramework
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SUS.Http;
    using SUS.Http.Contracts;
    using SUS.MvcFramework.Contracts;

    public static class Host
    {
        public static async Task CreateHostAsync(IMvcApplication application, int port = 80)
        {
            List<Route> routeTable = new List<Route>();
            application.ConfigureServices();
            application.Configure(routeTable);

            IHttpServer server = new HttpServer(routeTable);

            /*Set default browser to open localhost*/
            //Process.Start("chrome.exe", "http://localhost/");
            await server.StartAsync(port);
        }
    }
}
