using MediatR;
using TheVault.Domain.Boxes.Interfaces;

namespace TheVault.API.features.Boxes.UpdateBox;

public sealed class UpdateBoxCommandHandler(IBoxRepository repository) : IRequestHandler<UpdateBoxCommand>
{
    public async Task Handle(UpdateBoxCommand request, CancellationToken cancellationToken)
    {
        var box = await repository.GetBoxAsync(request.Id);



    }
}
