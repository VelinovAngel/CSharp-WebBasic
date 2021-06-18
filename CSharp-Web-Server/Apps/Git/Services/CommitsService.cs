namespace Git.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Git.Data;
    using Git.Data.Models;
    using Git.ViewModels.Commits;

    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public string CreateCommit(string description, string id, string userId, string repoId)
        {
            var creator = this.db.Users.Where(x => x.Id == userId).FirstOrDefault();

            var commit = new Commit
            {
                CreatorId = creator.Id,
                RepositoryId = repoId,
                CreatedOn = DateTime.UtcNow,
                Description = description
            };
            
            this.db.Commits.Add(commit);
            this.db.SaveChanges();
            return commit.Id;
        }

        public IEnumerable<CommitViewModel> GetAll()
            => this.db.Commits.Select(x => new CommitViewModel
            {
                CreatedOn = x.CreatedOn.ToString("g"),
                Description = x.Description,
                Repository = x.Repository.Name
            })
            .ToList();

        public string GetById(string id)
            => this.db.Repositories.Where(x => x.Id == id)
            .Select(x => x.Name)
            .FirstOrDefault();

        public void RemoveCommit(string userId)
        {
            var commit = this.db.Commits
                .FirstOrDefault(x => x.CreatorId == userId);
            if (commit == null)
            {
                return;
            }

            this.db.Commits.Remove(commit);
            this.db.SaveChanges();
        }
    }
}
