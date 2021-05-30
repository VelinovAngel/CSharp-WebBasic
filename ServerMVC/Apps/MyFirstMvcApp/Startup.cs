namespace MyFirstMvcApp
{
    using System.Collections.Generic;

    using SUS.Http;
    using SUS.Http.Enums;
    using SUS.MvcFramework.Contracts;
    using MyFirstMvcApp.Controllers;


    public class Startup : IMvcApplication
    {
        public void ConfigureServices()
        {            
        }

        public void Configure(List<Route> routeTable)
        {

        }
    }
}