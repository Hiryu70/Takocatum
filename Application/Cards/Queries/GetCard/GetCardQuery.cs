using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Cards.Queries.GetCard
{
    public class GetCardQuery : IRequest<GetCardDto>
    {
        public int Id { get; set; }

        public GetCardQuery(int id)
        {
            Id = id;
        }
    }

    public class GetCardQueryHandler : IRequestHandler<GetCardQuery, GetCardDto>
    {
        private readonly IMapper _mapper;

        public GetCardQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<GetCardDto> Handle(GetCardQuery request, CancellationToken cancellationToken)
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

            var dto = _mapper.Map<GetCardDto>(card);

            return dto;
        }
    }
}
