using MediatR;
using Microsoft.AspNetCore.Mvc;
using Takocatum.Dtos;
using Takocatum.Queries;

namespace Takocatum.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : Controller
    {
        private readonly ILogger<CardController> _logger;
        private readonly IMediator _mediator;

        public CardController(ILogger<CardController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetCard")]
        public async Task<CardDto> Get(int id)
        {
            _logger.Log(LogLevel.Information, $"GetCard. Id:{id}");
            return await _mediator.Send(new GetCardQuery(id));
        }
    }
}
