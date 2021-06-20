namespace CarShop.Services
{
    using CarShop.ViewModels.Users;


    public interface IUserService
    {
        void Register(RegisterUsersViewModel model);

        bool IsAvailableEmail(string email);

        bool IsAvailableUsername(string username);

        string GetUserId(string username, string password);
    }
}
