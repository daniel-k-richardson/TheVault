using Microsoft.EntityFrameworkCore;
using TheVault.Domain.Boxes.Entities;
using TheVault.Domain.Boxes.Interfaces;
using TheVault.Persistence.Data;

namespace TheVault.Persistence.Repositories;

public class BoxRepository(AppDataContext context) : IBoxRepository
{
    public async Task AddBoxAsync(Box box)
    {
        await context.Boxes.AddAsync(box);
        await context.SaveChangesAsync();
    }

    public async Task<Box?> GetBoxAsync(int id)
    {
        return await context.Boxes.FindAsync(id);
    }

    public async Task<IEnumerable<Box>> GetBoxesAsync()
    {
        return await context.Boxes.ToListAsync();
    }

    public async Task UpdateBoxAsync(Box box)
    {
        context.Boxes.Update(box);
        await context.SaveChangesAsync();
    }

    public async Task DeleteBoxAsync(int id)
    {
        var box = await context.Boxes.FindAsync(id);
        context.Boxes.Remove(box!);
        await context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
