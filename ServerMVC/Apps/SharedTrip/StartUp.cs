using SUS.Http;
using SharedTrip.Data;
using SUS.MvcFramework.Contracts;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SharedTrip
{
    internal class StartUp : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
        }
    }
}
           