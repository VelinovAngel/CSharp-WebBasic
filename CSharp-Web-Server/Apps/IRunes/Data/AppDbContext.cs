namespace IRunes.Data
{
    using IRunes.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        private const string SqlServerAddress = @"Server=.\SQLEXPRESS;Database=IRunes;Integrated Security=TRUE";

        public DbSet<User> Users { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Track> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SqlServerAddress);
            }
        }
    }
}
