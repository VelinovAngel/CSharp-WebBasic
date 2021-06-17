namespace MyWebServer.App.Services
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using MyWebServer.App.Data;
    using MyWebServer.App.Data.Models;
    using MyWebServer.App.ViewModels.Users;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Register(RegisterUserModel model)
        {
            var user = new User
            {
                Username = model.Username,
                Email = model.Password,
                Password = ComputeHash(model.Password),
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var userId = this.db.Users
                .FirstOrDefault(x => x.Username == username && x.Password == ComputeHash(password));
            return userId?.Id;
        }

        public bool IsAvailableEmail(string email)
            => !this.db.Users.Any(x => x.Email == email);
        public bool IsAvalaibleUser(string username)
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
