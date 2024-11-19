using MediatR;
using TheVault.Domain.Boxes.Entities;
using TheVault.Domain.Boxes.Interfaces;

namespace TheVault.API.features.Boxes.CreateBox;

public sealed class CreateBoxCommandHandler(IBoxRepository repository) : IRequestHandler<CreateBoxCommand>
{
    public async Task Handle(CreateBoxCommand request, CancellationToken cancellationToken)
    {
        var box = new Box(request.Label, request.Description, request.Location);
        box.SetItems(request.Items.Select(i => new Item(i.Name, i.Barcode, i.Quantity)).ToList());

        await repository.AddBoxAsync(box);
        await repository.SaveChangesAsync();
    }
}
