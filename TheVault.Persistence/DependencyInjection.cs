using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TheVault.Persistence.Data;

namespace TheVault.Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDataContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }
}
