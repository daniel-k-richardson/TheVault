using TheVault.Domain.Boxes.Entities;

namespace TheVault.API.features.Boxes.GetBox;

public record GetBoxQueryResponse
{
    public int Id { get; set; }
    public string Label { get; set; }
    public string? Description { get; set; }
    public string Location { get; set; }
    public IList<GetBoxQueryResponseItem> Items { get; set; }

    public sealed class GetBoxQueryResponseItem
    {
        public string Name { get; set; }
        public string? Barcode { get; set; }
        public decimal? Quantity { get; set; }
    }

    public static GetBoxQueryResponse BoxMapper(Box box)
    {
        return new GetBoxQueryResponse
        {
            Id = box.Id,
            Label = box.Label,
            Description = box.Description,
            Location = box.Location,
            Items = box.Items.Select(i => new GetBoxQueryResponseItem
            {
                Name = i.Name,
                Barcode = i.Barcode,
                Quantity = i.Quantity
            }).ToList()
        };
    }
}
