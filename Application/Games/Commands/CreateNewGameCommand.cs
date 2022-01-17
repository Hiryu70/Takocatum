using Domain.Entities;
using MediatR;

namespace Application.Games.Commands
{
    public class CreateNewGameCommand : IRequest<string>
    {

    }

    public class CreateNewGameCommandHandler : IRequestHandler<CreateNewGameCommand, string>
    {
        public async Task<string> Handle(CreateNewGameCommand request, CancellationToken cancellationToken)
        {
            var entity = new Game();

            return entity.ExternalId;
        }
    }
}
