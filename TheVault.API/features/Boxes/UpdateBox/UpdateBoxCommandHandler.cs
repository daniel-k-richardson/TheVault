using MediatR;
using TheVault.Domain.Boxes.Entities;
using TheVault.Domain.Boxes.Interfaces;

namespace TheVault.API.features.Boxes.UpdateBox;

public sealed class UpdateBoxCommandHandler(IBoxRepository repository) : IRequestHandler<UpdateBoxCommand>
{
    public async Task Handle(UpdateBoxCommand request, CancellationToken cancellationToken)
    {
        var box = await repository.GetBoxAsync(request.Id);
        if (box is null)
        {
            throw new ArgumentException("box not found");
        }

        box.SetItems(request.Items.Select(item => new Item(item.Name, item.Barcode, item.Quantity)).ToList());
        await repository.UpdateBoxAsync(box);
        await repository.SaveChangesAsync();
    }
}
