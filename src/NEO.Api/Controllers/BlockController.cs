using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NEO.Api.Queries;
using System.Linq;
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

            var response = await mediator.Send(new GetAllBlocksQuery(pageNumber, registersNumber));

            if (response.Errors.Any())
                return BadRequest(response.Errors); 

            return Ok(response.Result);
        }
    }
}
