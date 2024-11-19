using TheVault.API.features.Boxes.GetBox;
using TheVault.Domain.Boxes.Entities;

namespace TheVault.API.features.Boxes.BoxList;

public record GetBoxListQueryResponse
{
    public IList<GetBoxQueryResponse> Boxes { get; set; } = null!;

    public static GetBoxListQueryResponse BoxListMapper(IList<Box> boxes)
    {
        return new GetBoxListQueryResponse
        {
            Boxes = boxes.Select(GetBoxQueryResponse.BoxMapper).ToList()
        };
    }
}
