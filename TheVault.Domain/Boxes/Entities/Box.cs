using TheVault.Domain.Shared.Entities;
using TheVault.Domain.Shared.Interfaces;

namespace TheVault.Domain.Boxes.Entities;

public sealed class Box : Entity, IAggregateRoot
{
    public string Label { get; private set; }
    public string? Description { get; private set; }
    public string Location { get; private set; }
    public ICollection<Item> Items { get; private set; }

    private Box()
    {
    }

    public Box(string label, string location, string? description = null)
    {
        // todo: add validation
        Label = label;
        Location = location;
        Description = description;
        Items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        // todo: add validation
        Items.Add(item);
    }
}