using MediatR;
using Microsoft.EntityFrameworkCore;
using TheVault.Persistence.Data;

namespace TheVault.API.features.Boxes.BoxList;

public sealed class GetBoxListQueryHandler(AppDataContext context) : IRequestHandler<GetBoxListQuery, GetBoxListQueryResponse>
{
    public async Task<GetBoxListQueryResponse> Handle(GetBoxListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Boxes.ToListAsync(cancellationToken);
        return GetBoxListQueryResponse.BoxListMapper(result);
    }
}
