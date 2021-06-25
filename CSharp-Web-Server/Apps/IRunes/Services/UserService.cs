namespace IRunes.Services
{
    using System.Linq;
    using System.Text;
    using IRunes.Data;
    using IRunes.Data.Models;
    using IRunes.ViewModels.Users;
    using System.Security.Cryptography;


    public class UserService : IUserService
    {
        private readonly AppDbContext db;

        public UserService(AppDbContext db)
        {
            this.db = db;
        }

        public string GetUseId(string username, string password)
        {
            var userId = this.db.Users
                .FirstOrDefault(x => x.Username == username && 
                                x.Password == ComputeHash(password));
            return userId?.Id;
        }

        public bool IsAvailableEmail(string email)
            => !this.db.Users.Any(x => x.Email == email);

        public bool IsAvailableUsername(string username)
            => !this.db.Users.Any(x => x.Username == username);

        public void Register(RegisterUserFormModel model)
        {
            var user = new User
            {
                Username = model.Username,
                Password = ComputeHash(model.Password),
                Email = model.Email
            };
            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            var hashedInputStringBuilder = new StringBuilder(128);

            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }

        public LoginViewModel GerUserName(string id)
            => this.db.Users
            .Where(x => x.Id == id)
            .Select(x => new LoginViewModel
            {
                Username = x.Username,
                Password = x.Password
            })
            .FirstOrDefault();
    }
}
