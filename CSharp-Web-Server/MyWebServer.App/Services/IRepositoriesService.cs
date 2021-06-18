namespace MyWebServer.App.Services
{
    using MyWebServer.App.ViewModels.Repositories;

    public interface IRepositoriesService
    {
        void CreateRepository(RegistrationViewModel registration, string userId);

        bool IsPubluc(string repositoryType);
    }
}
