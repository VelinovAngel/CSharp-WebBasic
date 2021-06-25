namespace IRunes.Services
{
    using IRunes.ViewModels.Users;

    public interface IUserService
    {
        void Register(RegisterUserFormModel model);

        bool IsAvailableEmail(string email);

        bool IsAvailableUsername(string username);

        string GetUseId(string username, string email);

        public LoginViewModel GerUserName(string id);
    }
}
