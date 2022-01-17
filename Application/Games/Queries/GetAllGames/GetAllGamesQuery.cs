using MediatR;

namespace Application.Games.Queries.GetAllGames
{
    public class GetAllGames : IRequest<IEnumerable<GetAllGamesDto>>
    {
    }


}
