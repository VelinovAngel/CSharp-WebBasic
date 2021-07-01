namespace SharedTrip.Services
{
    using System.Text;
    using System.Linq;
    using System.Security.Cryptography;

    using SharedTrip.Data;
    using SharedTrip.Models;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = ComputeHash(password)
            };

            db.Users.Add(user);
            db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var user = db.Users
                .FirstOrDefault(x => x.Username == username &&
                                x.Password == ComputeHash(password));
            return user?.Id;
        }

        public bool IsEmailAvailable(string email)
            => !db.Users.Any(x => x.Email == email);

        public bool IsUserAvailable(string username)
            => !db.Users.Any(x => x.Username == username);

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();

            var hashedInputBytes = hash.ComputeHash(bytes);
            var hashedInputStringBuilder = new StringBuilder(128);

            foreach (var b in hashedInputBytes)
            {
                hashedInputStringBuilder.Append(b.ToString("X2"));
            }
            return hashedInputStringBuilder.ToString();
        }
    }
}
