using MediatR;
using TheVault.API.Interfaces;

namespace TheVault.API.features.Boxes.GetBox;

public sealed class GetBoxQueryEndpoint : IEndpoints
{
    public void DefineEndpoint(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/boxes/{id:int}", async (
            IMediator mediator,
            int id,
            CancellationToken cancellationToken) =>
        {
            var query = new GetBoxQuery(id);
            try
            {
                var response = await mediator.Send(query, cancellationToken);
                return Results.Ok(response);
            }
            catch (ArgumentException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}
