using Domain.Enums;

namespace Domain.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public CardType CardType { get; set; }
        public Color Color { get; set; }
        public bool Odd { get; set; }
        public Info Info { get; set; }
    }

    public class Info
    {
        public string Text { get; set; }
        public string Next { get; set; }
    }
}
