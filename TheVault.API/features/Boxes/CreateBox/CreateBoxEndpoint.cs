using MediatR;
using TheVault.API.Interfaces;

namespace TheVault.API.features.Boxes.CreateBox;

public class CreateBoxEndpoint : IEndpoints
{
    public void DefineEndpoint(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/boxes", async (IMediator mediator, CreateBoxCommand command) =>
        {
            await mediator.Send(command);
            return Results.Ok();
        });
    }
}
