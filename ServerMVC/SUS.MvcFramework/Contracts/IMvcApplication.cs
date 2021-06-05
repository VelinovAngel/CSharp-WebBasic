namespace SUS.MvcFramework.Contracts
{
    using SUS.Http;
    using System.Collections.Generic;

    public interface IMvcApplication
    {
        void ConfigureServices(IServiceCollection serviceCollection);

        void Configure(List<Route> routeTable);
    }
}
