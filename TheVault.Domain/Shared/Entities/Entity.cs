namespace TheVault.Domain.Shared.Entities;

public abstract class Entity
{
    public int Id { get; init; }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity entity)
        {
            return false;
        }

        return entity.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
