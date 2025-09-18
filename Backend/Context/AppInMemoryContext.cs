using Microsoft.EntityFrameworkCore;

namespace MyApp.Backend.Context
{
    public class AppInMemoryContext : AppContext
    {
        public AppInMemoryContext(DbContextOptions<AppInMemoryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
