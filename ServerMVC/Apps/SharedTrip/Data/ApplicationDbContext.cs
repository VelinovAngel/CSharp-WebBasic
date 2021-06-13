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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SqlServer);
            }
        }


    }
}
