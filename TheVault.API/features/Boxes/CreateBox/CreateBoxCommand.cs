using MediatR;

namespace TheVault.API.features.Boxes.CreateBox;

public sealed class CreateBoxCommand : IRequest
{
    public int Id { get; set; }
    public string Label { get; set; }
    public string? Description { get; set; }
    public string Location { get; set; }
    public IList<CreateBoxCommandItem> Items { get; set; }

    public sealed class CreateBoxCommandItem
    {
        public string Name { get; set; }
        public string? Barcode { get; set; }
        public decimal? Quantity { get; set; }
    }
}
