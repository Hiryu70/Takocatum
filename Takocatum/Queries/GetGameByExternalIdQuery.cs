using MediatR;
using Takocatum.Dtos;

namespace Takocatum.Queries
{
    internal class GetGameByExternalIdQuery : IRequest<GameDto>
    {
    }
}