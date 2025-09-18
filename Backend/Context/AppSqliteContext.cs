using Microsoft.EntityFrameworkCore;

namespace MyApp.Backend.Context
{
    public class AppSqliteContext : AppContext
    {
        public AppSqliteContext(DbContextOptions<AppSqliteContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
