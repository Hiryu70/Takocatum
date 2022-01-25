using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Infrastructure.Services
{
    internal class GameCacheService : IGameCacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly DistributedCacheEntryOptions _options;
        private const string Prefix = "game_";

        public GameCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
            _options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(120),
                SlidingExpiration = TimeSpan.FromSeconds(60)
            };
        }

        public async Task<Game> GetByExternalId(string externalId)
        {
            var key = Prefix + externalId;
            var cache = await _distributedCache.GetStringAsync(key);
            if (cache is null)
            {
                return null;
            }
            var game = JsonConvert.DeserializeObject<Game>(cache);
            return game;
        }

        public async Task Set(Game content)
        {
            var key = Prefix + content.ExternalId;
            var gameString = JsonConvert.SerializeObject(content);
            await _distributedCache.SetStringAsync(key, gameString, _options);
        }
    }
}
