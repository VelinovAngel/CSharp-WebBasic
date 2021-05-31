namespace MyFirstMvcApp
{
    using System.Collections.Generic;

    using SUS.Http;
    using BattleCards.Data;
    using SUS.MvcFramework.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices()
        {            
        }

        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }
    }
}