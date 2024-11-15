using TheVault.Domain.Shared.Entities;

namespace TheVault.Domain.Boxes.Entities;

public sealed class Item : Entity
{
    public string Name { get; set; }
    public string? Barcode { get; set; }
    public decimal? Quantity { get; set; }

    private Item()
    {
    }

    public Item(string name, string? barcode = null, decimal? quantity = null)
    {
        //todo: add validation
        Name = name;
        Barcode = barcode;
        Quantity = quantity;
    }
}
