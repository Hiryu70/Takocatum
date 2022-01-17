using Application.Common.Mapping;
using Domain.Entities;
using Domain.Enums;

namespace Application.Games.Queries.GetGameByExternalId
{
    public class GetGameByExternalIdDto : IMapFrom<Game>
    {
        public Guid Id { get; set; }
        public string ExternalId { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public GameStatus GameStatus { get; set; }
    }
}