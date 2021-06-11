namespace Suls
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using SUS.Http;
    using Suls.Data;
    using Suls.Services;
    using SUS.MvcFramework.Contracts;

    public class StartUp : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new DbApplicationContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<ISubmissionService, SubmissionService>();
            serviceCollection.Add<IUserService, UserService>();
            serviceCollection.Add<IProblemService, ProblemService>();
        }
    }
}
