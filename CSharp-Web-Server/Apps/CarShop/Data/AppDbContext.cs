namespace CarShop.Data
{
    using CarShop.Data.Models;
    using Microsoft.EntityFrameworkCore;


    public class AppDbContext : DbContext
    {
        private static string SqlServerAddress = @"Server=.\SQLEXPRESS;Database=CarShop;Integrated Security=TRUE;";

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Issue> Issues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SqlServerAddress);
            }
        }
    }
}
