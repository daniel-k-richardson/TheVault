using MediatR;
using TheVault.API.Interfaces;

namespace TheVault.API.features.Boxes.UpdateBox;

public class UpdateBoxEndpoint : IEndpoints
{
    public void DefineEndpoint(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPut("/api/boxes/{id:int}", async (IMediator mediator, int id, UpdateBoxCommand command) =>
        {
            // todo: add validation
            command.Id = id;
            await mediator.Send(command);
            return Results.NoContent();
        });
    }
}
