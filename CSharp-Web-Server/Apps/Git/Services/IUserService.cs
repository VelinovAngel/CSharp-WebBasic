namespace Git.Services
{
    using Git.ViewModels.Users;


    public interface IUserService
    {
        void Register(RegisterUserModel model);

        bool IsAvalaibleUser(string username);

        bool IsAvailableEmail(string email);

        string GetUserId(string username, string password);
    }
}
