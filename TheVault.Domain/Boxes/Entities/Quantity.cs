namespace TheVault.Domain.Boxes.Entities;

public sealed class Quantity
{
    public QuantityType QuantityType { get; init; }
    public decimal Value { get; init; }

    private Quantity()
    {
    }

    public Quantity(QuantityType quantityType, decimal value)
    {
        AssertValidValue(value);
        AssertValidQuantityType(quantityType);

        QuantityType = quantityType;
        Value = value;
    }

    private static void AssertValidValue(decimal value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Value must be greater than 0", nameof(value));
        }
    }

    private static void AssertValidQuantityType(QuantityType quantityType)
    {
        if (!Enum.IsDefined(quantityType))
        {
            throw new ArgumentException("QuantityType must be known", nameof(quantityType));
        }
    }
}
