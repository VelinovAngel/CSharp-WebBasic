namespace MyFirstMvcApp.Controllers
{
    using SUS.Http;
    using SUS.MvcFramework;
    using System;

    public class StaticFileController : Controller
    {
        public HttpResponse Favicon(HttpRequest request)
        {
            return this.File("wwwroot/favicon.ico", "image/vnd.microsoft.icon");
        }

        internal HttpResponse Bootstrap(HttpRequest request)
        {
            return this.File("wwwroot/css/bootstrap.min.css", "text/css");
        }

        internal HttpResponse CustomCss(HttpRequest request)
        {
            return this.File("wwwroot/css/custom.css", "text/css");
        }

        internal HttpResponse CustomJs(HttpRequest request)
        {
            return this.File("wwwroot/js/bootstrap.bundle.min.js", "text/javascript");
        }

        internal HttpResponse BootstrapJs(HttpRequest request)
        {
            return this.File("wwwroot/js/custom.js", "text/javascript");
        }
    }
}
