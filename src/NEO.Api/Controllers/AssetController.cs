using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NEO.Api.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace NEO.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/Assets")] 
    public class AssetController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;

        public AssetController(ILogger<TransactionController> logger)
        {
            _logger = logger; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IMediator mediator, [FromQuery] int pageNumber, [FromQuery] int registersNumber)
        {
            var response = await mediator.Send(new GetAllAssetsQuery(pageNumber, registersNumber)); 

            if (response.Errors.Any())
                return BadRequest(response.Errors);

            return Ok(response.Result);
        }
    }
}
