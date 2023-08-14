using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace DataBase;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];

        services.AddDbContext<SubscribeDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });
    
        services.AddScoped<IDbContext>(provider => provider.GetService<SubscribeDbContext>());
        return services;
    }
}