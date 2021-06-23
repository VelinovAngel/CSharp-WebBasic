using Andrey.ViewModels.Users;

namespace Andrey.Services
{
    public interface IUserService
    {
        void Register(RegistrationUsersFormModel model);

        bool IsAvailableUsername(string username);

        bool IsAvailableEmail(string email);

        string GetUserId(string username, string password);
    }
}
