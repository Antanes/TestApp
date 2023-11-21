using TestApp.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace TestApp.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<DrinksDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IDrinksDbContext>(provider =>
                provider.GetService<DrinksDbContext>());
            return services;
        }
    }
}