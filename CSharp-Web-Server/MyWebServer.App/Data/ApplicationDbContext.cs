namespace MyWebServer.App.Data
{
    using Microsoft.EntityFrameworkCore;


    public class ApplicationDbContext : DbContext
    {
        private const string SqlServerAddress = @"Server=.\SQLEXPRESS;Database=Git;Integrated Security=TRUE";
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {
        }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SqlServerAddress);
            }
        }
    }
}
