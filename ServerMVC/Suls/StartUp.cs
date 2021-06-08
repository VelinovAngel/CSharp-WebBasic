namespace Suls
{
    using SUS.Http;
    using SUS.MvcFramework.Contracts;

    using System.Collections.Generic;

    public class StartUp : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            //db.migrate
            throw new System.NotImplementedException();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Dependency container
            throw new System.NotImplementedException();
        }
    }
}
