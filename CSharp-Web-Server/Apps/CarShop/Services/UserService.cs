namespace CarShop.Services
{
    using System.Text;
    using System.Linq;
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.ViewModels.Users;
    using System.Security.Cryptography;

    public class UserService : IUserService
    {
        private readonly AppDbContext db;

        public UserService(AppDbContext db)
        {
            this.db = db;
        }
        public void Register(RegisterUsersViewModel model)
        {
            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = ComputeHash(model.Password),
                IsMechanic = model.UserType == "Mechanic" ? true : false 
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

        public bool IsAvailableUsername(string username)
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
