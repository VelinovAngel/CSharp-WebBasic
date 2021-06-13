namespace BattleCards
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using SUS.Http;
    using SUS.MvcFramework.Contracts;
    
    using BattleCards.Data;
    using BattleCards.Services;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<ICardsService, CardsService>();
        }

        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }
    }
}