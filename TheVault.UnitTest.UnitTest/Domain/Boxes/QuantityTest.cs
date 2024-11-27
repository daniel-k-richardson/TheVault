using TheVault.Domain.Boxes.Entities;

namespace TheVault.UnitTest.UnitTest.Domain.Boxes;

[TestFixture]
public sealed class QuantityTest
{
    [Test]
    public void Constructor_HappyPath_IsCreated([Values]QuantityType quantityType, [Values(1, 2, 3)] decimal value)
    {
        // Arrange

        // Act
        var quantity = new Quantity(quantityType, value);

        // Assert
        Assert.That(quantityType, Is.EqualTo(quantity.QuantityType));
        Assert.That(value, Is.EqualTo(quantity.Value));
    }

    [Test]
    public void Constructor_ValueIsZero_ThrowsArgumentException([Values(-1, 0)] decimal value)
    {
        // Arrange

        // Act
        var exception = Assert.Throws<ArgumentException>(() => _ = new Quantity(QuantityType.Volume, value));

        // Assert
        Assert.That(exception.ParamName, Is.EqualTo("value"));
    }

    [Test]
    public void Constructor_QuantityTypeIsUnknown_ThrowsArgumentException()
    {
        // Arrange
        var quantityType = (QuantityType)int.MaxValue;

        // Act
        var exception = Assert.Throws<ArgumentException>(() => _ = new Quantity(quantityType, 1));

        // Assert
        Assert.That(exception.ParamName, Is.EqualTo("quantityType"));
    }
}
