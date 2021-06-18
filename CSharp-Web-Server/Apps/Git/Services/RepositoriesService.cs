namespace Git.Services
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Git.Data;
    using Git.Data.Models;
    using Git.ViewModels.Repositories;

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

        public IEnumerable<RepositoryViewModel> GetAllRepository()
            => this.db.Repositories.Select(x => new RepositoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreatedOn = x.CreatedOn.ToString("g"),
                Owner = x.Owner.Username,
                Commits = x.Commits.Count()
            })
            .ToList();

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
