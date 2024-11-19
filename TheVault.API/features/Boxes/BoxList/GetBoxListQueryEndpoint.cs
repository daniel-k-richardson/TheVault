using MediatR;
using TheVault.API.Interfaces;

namespace TheVault.API.features.Boxes.BoxList;

public sealed class GetBoxListQueryEndpoint : IEndpoints
{
    public void DefineEndpoint(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/boxes", async (IMediator mediator) =>
        {
            var query = new GetBoxListQuery();
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }).WithName("GetBoxList").WithTags("Boxes");;
    }
}
