﻿namespace SUS.MvcFramework
{
    using System;
    using System.IO;
    using System.Linq;
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
            AutoRegisterRoutes(routeTable, application);

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

        private static void AutoRegisterRoutes(List<Route> routeTable, IMvcApplication application)
        {
            var controllerTypes = application.GetType().Assembly.GetTypes().Where(x=>x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(Controller)));

            foreach (var controllerType in controllerTypes)
            {
                var methods = controllerType.GetMethods()
                    .Where(x=>x.IsPublic && !x.IsStatic && x.DeclaringType == controllerType && !x.IsAbstract && !x.IsConstructor && !x.IsSpecialName);
                foreach (var method in methods)
                {
                    var url = "/" + controllerType.Name.Replace("Controller", string.Empty) + "/" + method.Name;

                    var attributes = method.GetCustomAttributes(false)
                        .Where(x => x.GetType().IsSubclassOf(typeof(BaseHttpAttribute)))
                        .FirstOrDefault() as BaseHttpAttribute;
                    var httpMethod = HttpMethod.Get;

                    if (attributes != null)
                    {
                        httpMethod = attributes.Method;
                    }

                    if (!string.IsNullOrWhiteSpace(attributes?.Url))
                    {
                        url = attributes.Url;
                    }

                    routeTable.Add(new Route(url, httpMethod, (request) =>
                    {
                        var instance = Activator.CreateInstance(controllerType) as Controller;
                        instance.Request = request;
                        var response = method.Invoke(instance, new object[] { }) as HttpResponse;
                        return response;
                    }));
                    Console.WriteLine($" - {url}");
                }
            }
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
