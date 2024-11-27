namespace TheVault.Domain.Boxes.Entities;

public sealed class Item
{
    public string Name { get; init; }
    public string? Barcode { get; init; }
    public Quantity Quantity { get; init; }

    private Item()
    {
    }

    public Item(string name, string? barcode, Quantity quantity)
    {
        AssertValidName(name);
        AssertQuantityNotNull(quantity);

        Name = name;
        Barcode = barcode;
        Quantity = quantity;
    }

    private static void AssertQuantityNotNull(Quantity quantity)
    {
        if (quantity is null)
        {
            throw new ArgumentNullException(nameof(quantity));
        }
    }

    private static void AssertValidName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name must not be empty", nameof(name));
        }
    }
}
