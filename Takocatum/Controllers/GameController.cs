using MediatR;
using Microsoft.AspNetCore.Mvc;
using Takocatum.Dtos;

namespace Takocatum.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<CardController> _logger;
        private readonly IMediator _mediator;

        public GameController(ILogger<GameController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<GameDto> Get(int id)
        {
            _logger.Log(LogLevel.Information, $"GetCard. Id:{id}");
            return await _mediator.Send(new GetCardQuery(id));
        }
    }
}
