using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IGameCacheService
    {
        Task<Game> GetByExternalId(string externalId);
        Task Set(Game content);
    }
}
