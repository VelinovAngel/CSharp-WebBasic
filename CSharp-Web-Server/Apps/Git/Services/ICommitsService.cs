namespace Git.Services
{
    using Git.ViewModels.Commits;
    using System.Collections.Generic;

    public interface ICommitsService
    {
        public string CreateCommit(string description, string id, string userId, string repoId);

        public void RemoveCommit(string userId);

        string GetById(string id);

        IEnumerable<CommitViewModel> GetAll();
    }
}
