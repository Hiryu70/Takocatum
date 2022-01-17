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

        public GetGameByExternalIdQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }


        async Task<GetGameByExternalIdDto> IRequestHandler<GetGameByExternalIdQuery, GetGameByExternalIdDto>.Handle(GetGameByExternalIdQuery request, CancellationToken cancellationToken)
        {
            var game = new Game();

            var dto = _mapper.Map<GetGameByExternalIdDto>(game);

            return dto;
        }
    }
}