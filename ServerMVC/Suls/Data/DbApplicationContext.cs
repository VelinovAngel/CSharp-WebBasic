namespace Suls.Data
{
    using Microsoft.EntityFrameworkCore;

    public class DbApplicationContext : DbContext
    {
        private const string SqlServer = @"Server=.\SQLEXPRESS;Database=Suls;Integrated Security=TRUE";

        public DbApplicationContext()
        {
        }
        public DbApplicationContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        { 
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SqlServer);
            }
        }
    }


}
