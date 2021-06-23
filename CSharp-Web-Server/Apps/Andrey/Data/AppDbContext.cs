using Andrey.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Andrey.Data
{
    public class AppDbContext : DbContext
    {
        private const string SqlServerAddress = @"Server=.\SQLEXPRESS;Database=Andrey;Integrated Security=TRUE;";

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SqlServerAddress);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Product>()
                 .Property(x => x.Id)
                 .ValueGeneratedOnAdd();
        }
    }
}
