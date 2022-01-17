using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Cards.Queries.GetCard
{
    public class GetCardDto : IMapFrom<Card>
    {
        public CardType CardType { get; set; }
        public string Color { get; set; }
        public bool Odd { get; set; }
        public string Text { get; set; }
        public string Next { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Card, GetCardDto>().IncludeMembers(s => s.Info);
            profile.CreateMap<Info, GetCardDto>();
        }
    }
}
