using TheVault.Domain.Boxes.Entities;

namespace TheVault.UnitTest.UnitTest.Domain.Boxes;

[TestFixture]
public sealed class ItemTest
{

    private Quantity _quantity;

    [SetUp]
    public void Setup()
    {
        _quantity = new Quantity(QuantityType.Weight, 1);
    }

    [Test]
    [TestCase("Item Name", "1234567890")]
    [TestCase("Item Name", "")]
    [TestCase("Item Name", null)]
    public void Constructor_HappyPath_IsCreated(string name, string? barcode)
    {
        // Arrange

        // Act
        var item = new Item(name, barcode, _quantity);

        // Assert
        Assert.That(name, Is.EqualTo(item.Name));
        Assert.That(barcode, Is.EqualTo(item.Barcode));
        Assert.That(_quantity, Is.EqualTo(item.Quantity));
    }

    [Test]
    public void Constructor_NameIsNull_ThrowsArgumentException([Values(null, "")] string? name)
    {
        // Arrange
        var quantity = new Quantity(QuantityType.Weight, 1);

        // Act
        var exception = Assert.Throws<ArgumentException>(() => _ = new Item(name!, "Barcode", quantity));

        // Assert
        Assert.That(exception.ParamName, Is.EqualTo("name"));
    }

    [Test]
    public void Constructor_QuantityIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        Quantity? quantity = null;

        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => _ = new Item("Name", "Barcode", quantity!));

        // Assert
        Assert.That(exception.ParamName, Is.EqualTo("quantity"));
    }
}
