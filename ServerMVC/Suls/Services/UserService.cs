namespace Suls.Services
{
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;

    using Suls.Data;

    public class UserService : IUserService
    {
        private readonly DbApplicationContext db;

        public UserService(DbApplicationContext db)
        {
            this.db = db;
        }

        public void CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Email = email,
                Username = username,
                Password = ComputeHash(password),

            };

            db.Users.Add(user);
            db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var passwordHash = ComputeHash(password);
            var user = db.Users.FirstOrDefault(x => x.Username == username && x.Password == passwordHash);
            return user?.Id;
        }

        public bool IsEmailAvailable(string email)
                => !this.db.Users.Any(x => x.Email == email);

        public bool IsUserAvailable(string username)
                => !this.db.Users.Any(x => x.Username == username);

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            // Convert to text
            // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }
    }
}
