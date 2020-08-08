using MediatR;
using Microsoft.AspNetCore.Mvc;
using NEO.Api.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace NEO.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/transactions")]
    public class TransactionController : ControllerBase
    { 
        [HttpGet("{transactionHash}")]
        public async Task<IActionResult> Detail([FromServices]IMediator mediator, string transactionHash)   
        {
            var response = await mediator.Send(new GetTransactionDetailByHashQuery(transactionHash));

            if (response.Errors.Any())
                return BadRequest(response.Errors);

            return Ok(response.Result);
        }
    }
}
