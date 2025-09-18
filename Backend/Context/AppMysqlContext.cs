using Microsoft.EntityFrameworkCore;

namespace MyApp.Backend.Context
{
    public class AppMysqlContext : AppContext
    {
        public AppMysqlContext(DbContextOptions<AppMysqlContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
