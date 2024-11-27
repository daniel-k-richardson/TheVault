using MediatR;
using TheVault.Domain.Boxes.Entities;

namespace TheVault.API.features.Boxes.CreateBox;

public sealed class CreateBoxCommand : IRequest
{
    public string Label { get; set; }
    public string? Description { get; set; }
    public string Location { get; set; }
    public IList<CreateBoxCommandItem> Items { get; set; }

    public sealed class CreateBoxCommandItem
    {
        public string Name { get; set; }
        public string? Barcode { get; set; }
        public Quantity Quantity { get; set; }
    }
}
