using Microsoft.EntityFrameworkCore;
using TheVault.Domain.Boxes.Entities;

namespace TheVault.Persistence.Data;

public sealed class AppDataContext(DbContextOptions<AppDataContext> options) : DbContext(options)
{
    public DbSet<Box> Boxes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDataContext).Assembly);
    }
}

