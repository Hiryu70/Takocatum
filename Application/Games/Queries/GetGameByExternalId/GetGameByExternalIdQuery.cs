using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Games.Queries.GetGameByExternalId
{
    public class GetGameByExternalIdQuery : IRequest<GetGameByExternalIdDto>
    {
        public string ExternalId { get; set; }

        public GetGameByExternalIdQuery(string externalId)
        {
            ExternalId = externalId;
        }
    }

    public class GetGameByExternalIdQueryHandler : IRequestHandler<GetGameByExternalIdQuery, GetGameByExternalIdDto>
    {
        private readonly IMapper _mapper;
        private readonly IGameCacheService _gameCacheService;

        public GetGameByExternalIdQueryHandler(IMapper mapper, IGameCacheService gameCacheService)
        {
            _mapper = mapper;
            _gameCacheService = gameCacheService;
        }


        async Task<GetGameByExternalIdDto> IRequestHandler<GetGameByExternalIdQuery, GetGameByExternalIdDto>.Handle(GetGameByExternalIdQuery request, CancellationToken cancellationToken)
        {
            Game game = await _gameCacheService.GetByExternalId(request.ExternalId);
            if (game is null)
            {
                game = new Game() { ExternalId = request.ExternalId};
                await _gameCacheService.Set(game);
            }

            var dto = _mapper.Map<GetGameByExternalIdDto>(game);

            return dto;
        }
    }
}