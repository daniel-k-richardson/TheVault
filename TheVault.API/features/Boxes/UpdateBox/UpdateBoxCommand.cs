using MediatR;

namespace TheVault.API.features.Boxes.UpdateBox;

public class UpdateBoxCommand : IRequest
{
    public int Id { get; set; }
    public string Label { get; set; }
    public string? Description { get; set; }
    public string Location { get; set; }
    public IList<UpdateBoxCommandItem> Items { get; set; }

    public sealed class UpdateBoxCommandItem
    {
        public string Name { get; set; }
        public string? Barcode { get; set; }
        public decimal? Quantity { get; set; }
    }
}
