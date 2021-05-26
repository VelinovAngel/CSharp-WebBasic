namespace SUS.MvcFramework
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using SUS.Http;
    using SUS.Http.Contracts;

    public static class Host
    {
        public static async Task CreateHostAsync(List<Route> routesTable, int port = 80)
        {
            IHttpServer server = new HttpServer(routesTable);

            /*Set default browser to open localhost*/
            //Process.Start("chrome.exe", "http://localhost/");
            await server.StartAsync(port);
        }
    }
}
