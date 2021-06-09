namespace Suls.Data
{
    using Microsoft.EntityFrameworkCore;

    public class DbApplicantionContext : DbContext
    {
        private const string SqlServer = @"Server=.\SQLEXPRESS;Database=Suls;Integrated Security=TRUE";

        protected DbApplicantionContext()
        {
        }
        public DbApplicantionContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
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
