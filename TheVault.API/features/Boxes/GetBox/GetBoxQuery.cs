using MediatR;

namespace TheVault.API.features.Boxes.GetBox;

public record GetBoxQuery(int Id) : IRequest<GetBoxQueryResponse>;
