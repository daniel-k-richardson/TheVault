using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TheVault.Domain.Boxes.Interfaces;
using TheVault.Persistence.Data;
using TheVault.Persistence.Repositories;

namespace TheVault.Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDataContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IBoxRepository, BoxRepository>();
    }
}
