namespace Git.Data
{
    using Microsoft.EntityFrameworkCore;
    using Git.Data.Models;

    public class ApplicationDbContext : DbContext
    {
        private const string SqlServerAddress = @"Server=.\SQLEXPRESS;Database=Git;Integrated Security=TRUE";

        public DbSet<User> Users { get; set; }

        public DbSet<Commit> Commits { get; set; }

        public DbSet<Repository> Repositories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SqlServerAddress);
            }
        }
    }
}
