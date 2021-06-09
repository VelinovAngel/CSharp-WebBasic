namespace Suls
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using SUS.Http;
    using Suls.Data;
    using SUS.MvcFramework.Contracts;

    public class StartUp : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new DbApplicantionContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            throw new System.NotImplementedException();
        }
    }
}
