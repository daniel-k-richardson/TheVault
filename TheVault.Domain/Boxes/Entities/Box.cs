using TheVault.Domain.Shared.Entities;
using TheVault.Domain.Shared.Interfaces;

namespace TheVault.Domain.Boxes.Entities;

public sealed class Box : Entity, IAggregateRoot
{
    public string Label { get; private set; }
    public string? Description { get; private set; }
    public string Location { get; private set; }
    public List<Item> Items { get; private set; }

    private Box()
    {

    }

    public Box(string label, string location, string? description = null)
    {
        AssertValidLabel(label);
        AssertValidLocation(location);

        Label = label;
        Location = location;
        Description = description;
        Items = [];
    }

    public void SetItems(IList<Item> items)
    {
        if (items is null)
        {
            throw new ArgumentNullException(nameof(items), "Items cannot not be null");
        }

        if (!items.Any())
        {
            throw new ArgumentException("Items must contain values", nameof(items));
        }

        Items.Clear();
        Items.AddRange(items);
    }

    private static void AssertValidLabel(string label)
    {
        if (string.IsNullOrWhiteSpace(label))
        {
            throw new ArgumentException("Label must not be empty", nameof(label));
        }
    }

    private static void AssertValidLocation(string location)
    {
        if (string.IsNullOrWhiteSpace(location))
        {
            throw new ArgumentException("Location must not be empty", nameof(location));
        }
    }
}
