namespace BattleCards.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);

        bool IsUserValid(string username, string password);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);
    }
}
