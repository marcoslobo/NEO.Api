using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NEO.Api.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace NEO.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger) 
        {
            _logger = logger;
        }

        [HttpGet("{transactionHash}")]
        public async Task<IActionResult> Detail([FromServices]IMediator mediator, string transactionHash)   
        {
            var response = await mediator.Send(new GetTransactionDetailByHashQuery(transactionHash));

            if (response.Errors.Any())
                return BadRequest(response.Errors);

            return Ok(response.Result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IMediator mediator, [FromQuery] int pageNumber, [FromQuery] int registersNumber) 
        {
            var response = await mediator.Send(new GetAllTransactionsQuery(pageNumber, registersNumber));   

            if (response.Errors.Any())
                return BadRequest(response.Errors);

            return Ok(response.Result);  
        }
    }
}
