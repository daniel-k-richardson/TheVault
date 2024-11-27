using TheVault.Domain.Boxes.Entities;

namespace TheVault.UnitTest.UnitTest.Domain.Boxes;

[TestFixture]
public sealed class BoxTest
{
    [Test]
    public void Constructor_HappyPath_IsCreated([Values("desciption", "", null)] string? description)
    {
        // Arrange

        // Act
        var box = new Box("Box label", "Box location", description);

        // Assert
        Assert.That(box.Label, Is.EqualTo("Box label"));
        Assert.That(box.Location, Is.EqualTo("Box location"));
        Assert.That(box.Description, Is.EqualTo(description));
    }

    [Test]
    public void Constructor_InvalidLabel_ThrowsException([Values("", " ", null)] string? label)
    {
        // Arrange

        // Act
        var exception = Assert.Throws<ArgumentException>(() => _ = new Box(label!, "Box location"));

        // Assert
        Assert.That(exception.ParamName, Is.EqualTo("label"));
    }

    [Test]
    public void Constructor_InvalidLocation_ThrowsException([Values("", " ", null)] string? location)
    {
        // Arrange

        // Act
        var exception = Assert.Throws<ArgumentException>(() => _ = new Box("Box label", location!));

        // Assert
        Assert.That(exception.ParamName, Is.EqualTo("location"));
    }

    [Test]
    public void SetItems_HappyPath_IsSet()
    {
        // Arrange
        var box = new Box("Box label", "Box location");
        var items = new List<Item>
        {
            new Item("Item name", "1234567890", new Quantity(QuantityType.Weight, 1))
        };

        // Act
        box.SetItems(items);

        // Assert
        Assert.That(box.Items, Is.EqualTo(items));
    }

    [Test]
    public void SetItems_NullItems_ThrowsArgumentNullException()
    {
        // Arrange
        var box = new Box("Box label", "Box location");
        List<Item>? items = null;

        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => box.SetItems(items!));

        // Assert
        Assert.That(exception.ParamName, Is.EqualTo("items"));
    }

    [Test]
    public void SetItems_EmptyItems_ThrowsArgumentException()
    {
        // Arrange
        var box = new Box("Box label", "Box location");
        var items = new List<Item>();

        // Act
        var exception = Assert.Throws<ArgumentException>(() => box.SetItems(items));

        // Assert
        Assert.That(exception.ParamName, Is.EqualTo("items"));
    }

    [Test]
    public void SetItems_NewItems_OverridesExisting()
    {
        // Arrange
        var box = new Box("Box label", "Box location");
        var items = new List<Item>
        {
            new Item("Item name", "1234567890", new Quantity(QuantityType.Weight, 1))
        };
        box.SetItems(items);

        var newItems = new List<Item>
        {
            new Item("New item name", "0987654321", new Quantity(QuantityType.Weight, 2))
        };

        // Act
        box.SetItems(newItems);

        // Assert
        Assert.That(box.Items, Is.Not.EqualTo(items));
        Assert.That(box.Items, Is.EqualTo(newItems));
    }
}
