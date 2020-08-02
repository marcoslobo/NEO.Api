using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NEO.Api.Queries;
using System.Threading.Tasks;

namespace NEO.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/blocks")]
    public class BlockController : ControllerBase
    {
        private readonly ILogger<BlockController> _logger;

        public BlockController(ILogger<BlockController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices]IMediator mediator, [FromQuery]int pageNumber, [FromQuery]int registersNumber)
        {
            return Ok(await mediator.Send(new GetAllBlocksQuery(pageNumber, registersNumber)));
        }
    }
}
