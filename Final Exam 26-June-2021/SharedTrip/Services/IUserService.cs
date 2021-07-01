namespace SharedTrip.Services
{
    public interface IUserService
    {
        void CreateUser(string username, string email, string password);

        string GetUserId(string username, string password);

        bool IsEmailAvailable(string email);

        bool IsUserAvailable(string username);
    }
}
