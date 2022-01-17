using Domain.Enums;

namespace Domain.Entities
{
    public class Game
    {
        public Guid Id { get; set; }
        public string ExternalId { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public GameStatus GameStatus { get; set; }

        public Game()
        {
            ExternalId = GenerateExternalId();
            GameStatus = GameStatus.AwaitingPlayers;
        }

        private string GenerateExternalId()
        {
            return "AwkW37d";
        }
    }
}
