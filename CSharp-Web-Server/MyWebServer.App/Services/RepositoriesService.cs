namespace MyWebServer.App.Services
{
    using MyWebServer.App.Data;
    using MyWebServer.App.Data.Models;
    using MyWebServer.App.ViewModels.Repositories;
    using System;

    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateRepository(RegistrationViewModel registration , string userId)
        {
            var isPublic = IsPubluc(registration.RepositoryType);
            var repository = new Repository
            {
                Name = registration.Name,
                IsPublic = isPublic,
                CreatedOn = DateTime.UtcNow,
                OwnerId = userId,
            };
            this.db.Repositories.Add(repository);
            this.db.SaveChanges();
        }

        public bool IsPubluc(string repositoryType)
        {
            if (repositoryType == "Private")
            {
                return false;
            }
            return true;
        }
    }
}
