using MyWebServer.App.ViewModels.Users;

namespace MyWebServer.App.Services
{
    public interface IUserService
    {
        void Register(RegisterUserModel model);

        bool IsAvalaibleUser(string username);

        bool IsAvailableEmail(string email);

        string GetUserId(string username, string password);
    }
}
