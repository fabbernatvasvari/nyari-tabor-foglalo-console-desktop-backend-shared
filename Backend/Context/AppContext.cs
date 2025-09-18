using Microsoft.EntityFrameworkCore;

namespace MyApp.Backend.Context
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {
        }
    }
}
