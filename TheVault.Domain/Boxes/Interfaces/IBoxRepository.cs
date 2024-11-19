using TheVault.Domain.Boxes.Entities;

namespace TheVault.Domain.Boxes.Interfaces;

public interface IBoxRepository
{
    Task AddBoxAsync(Box box);
    Task<Box?> GetBoxAsync(int id);
    Task<IEnumerable<Box>> GetBoxesAsync();
    Task UpdateBoxAsync(Box box);
    Task DeleteBoxAsync(int id);
    Task SaveChangesAsync();
}
