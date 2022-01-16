using AutoMapper;
using MediatR;
using Takocatum.Dtos;

namespace Takocatum.Queries
{
    public class GetCardQuery : IRequest<CardDto>
    {
        public int Id { get; set; }

        public GetCardQuery(int id)
        {
            Id = id;
        }
    }

    public class GetCardQueryHandler : IRequestHandler<GetCardQuery, CardDto>
    {
        public GetCardQueryHandler()
        {
        }

        public async Task<CardDto> Handle(GetCardQuery request, CancellationToken cancellationToken)
        {
            var card = new Card()
            {
                Id = request.Id,
                CardType = CardType.Cat,
                Color = Color.Blue,
                Odd = false,
                Info = new Info
                {
                    Text = "Просто тест маппера",
                    Next = "Рили"
                }
            };

            var config = new MapperConfiguration(cfg => 
                { 
                    cfg.CreateMap<Card, CardDto>().IncludeMembers(s => s.Info);
                    cfg.CreateMap<Info, CardDto>();
                }
            );
            var mapper = new Mapper(config);
            var dto = mapper.Map<CardDto>(card);

            return dto;
        }
    }
}
