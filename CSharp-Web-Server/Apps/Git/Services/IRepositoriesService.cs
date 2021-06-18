namespace Git.Services
{
    using Git.ViewModels.Repositories;
    using System.Collections.Generic;

    public interface IRepositoriesService
    {
        void CreateRepository(RegistrationViewModel registration, string userId);

        IEnumerable<RepositoryViewModel> GetAllRepository();

        bool IsPubluc(string repositoryType);
    }
}
