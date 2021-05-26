using SUS.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUS.MvcFramework
{
    public class Route
    {
        public Route(string path, Func<HttpRequest, HttpResponse> action)
        {
            this.Path = path;
            this.Action = action;
        }
        public string Path { get; set; }

        public Func<HttpRequest, HttpResponse> Action { get; set; }
    }
}
