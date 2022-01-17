using Application.Games.Queries.GetGameByExternalId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Takocatum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly IMediator _mediator;

        public GameController(ILogger<GameController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetGame")]
        public async Task<GetGameByExternalIdDto> GetGame(string externalId)
        {
            _logger.Log(LogLevel.Information, $"GetCard. Id:{externalId}");
            return await _mediator.Send(new GetGameByExternalIdQuery(externalId));
        }
    }
}
