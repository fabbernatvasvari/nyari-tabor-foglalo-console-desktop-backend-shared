using MyApp.Backend.Context;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Backend.Extensions
{
    public static class Extensions
    {
        public static void AddBackend(this IServiceCollection services)
        {
            services.ConfigureCors()
                .ConfigureInMemoryContext()
                .ConfigureMySqlContext()
                .ConfigureSqliteContext();

        }

        private static IServiceCollection ConfigureCors(this IServiceCollection services)
        {

            services.AddCors(option =>
                 option.AddPolicy(name: "MyAppCors",
                     policy =>
                     {
                         policy.WithOrigins("https://localhost:7020/")
                             .AllowAnyHeader()
                             .AllowAnyMethod();
                     }
                 )
            );
            return services;
        }

        private static IServiceCollection ConfigureInMemoryContext(this IServiceCollection services)
        {
            string dbNameInMemoryContext = "MyApp" + Guid.NewGuid();
            services.AddDbContext<AppInMemoryContext>
            (
                 options => options.UseInMemoryDatabase(databaseName: dbNameInMemoryContext),
                 ServiceLifetime.Scoped,
                 ServiceLifetime.Scoped
            );
            return services;
        }

        private static IServiceCollection ConfigureMySqlContext(this IServiceCollection services)
        {
            string database = "myapp";
            string connectionString = $"server=localhost;userid=root;password=;database={database};port=3306";
            services.AddDbContext<AppMysqlContext>(options => options.UseMySQL(connectionString));
            return services;
        }

        private static IServiceCollection ConfigureSqliteContext(this IServiceCollection services)
        {
            string dbPath = Path.Combine(Environment.CurrentDirectory, "myapp.db");
            services.AddDbContext<AppSqliteContext>
            (
                options => options.UseSqlite($"Data Source={dbPath}")
            );
            return services;
        }
    }
}
