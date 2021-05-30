namespace SUS.MvcFramework
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using SUS.Http;
    using SUS.Http.Enums;
    using SUS.Http.Contracts;
    using SUS.MvcFramework.Contracts;

    public static class Host
    {
        public static async Task CreateHostAsync(IMvcApplication application, int port = 80)
        {
            List<Route> routeTable = new List<Route>();

            AutoRegisterStaticFiles(routeTable);

            application.ConfigureServices();
            application.Configure(routeTable);

            Console.WriteLine("All register routes");
            foreach (var route in routeTable)
            {
                Console.WriteLine($"{route.Method} - {route.Path}");
            }

            IHttpServer server = new HttpServer(routeTable);

            /*Set default browser to open localhost*/
            //Process.Start("chrome.exe", "http://localhost/");
            await server.StartAsync(port);
        }

        private static void AutoRegisterStaticFiles(List<Route> routeTable)
        {
            var staticFiles = Directory.GetFiles("wwwroot", "*", SearchOption.AllDirectories);
            foreach (var staticFile in staticFiles)
            {
                var url = staticFile.Replace("wwwroot", string.Empty)
                    .Replace("\\", "/");
                routeTable.Add(new Route(url, HttpMethod.Get, (request) =>
                {
                    var fileConetnt = File.ReadAllBytes(staticFile);
                    var fileExt = new FileInfo(staticFile).Extension;
                    var contentType = fileExt switch
                    {
                        ".txt" => "text/plain",
                        ".js" => "text/javascript",
                        ".css" => "text/css",
                        ".jpg" => "image/jpg",
                        ".jpeg" => "image/jpg",
                        ".png" => "image/png",
                        ".gif" => "image/gif",
                        ".ico" => "image/vnd.microsoft.icon",
                        ".html" => "text/html",
                        _ => "text/plain"
                    };

                    var httpRespone = new HttpResponse(contentType, fileConetnt, HttpStatusCode.Ok);
                    return httpRespone;
                }));
            }
        }
    }
}
