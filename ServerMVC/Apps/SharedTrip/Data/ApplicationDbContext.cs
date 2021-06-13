using Microsoft.EntityFrameworkCore;

namespace SharedTrip.Data
{
    public class ApplicationDbContext : DbContext
    {
        private static string SqlServer = @"Server=.\SQLEXPRESS;Database=SharedTrip;Integrated Security=TRUE;";
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<UserTrip> UserTrips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SqlServer);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<UserTrip>()
                .HasKey(x => new
                {
                    x.TripId,
                    x.UserId
                });
        }
    }
}
