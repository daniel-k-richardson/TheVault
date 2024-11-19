using MediatR;
using TheVault.Persistence.Data;

namespace TheVault.API.features.Boxes.GetBox;

public sealed class GetBoxQueryHandler(AppDataContext context) : IRequestHandler<GetBoxQuery, GetBoxQueryResponse>
{
    public async Task<GetBoxQueryResponse> Handle(GetBoxQuery request, CancellationToken cancellationToken)
    {
        var box = await context.Boxes.FindAsync(request.Id, cancellationToken);

        if (box == null)
        {
            throw new ArgumentException("Box not found");
        }

        return GetBoxQueryResponse.BoxMapper(box);
    }
}
