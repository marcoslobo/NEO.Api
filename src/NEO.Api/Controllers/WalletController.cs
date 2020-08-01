using MediatR;
using Microsoft.AspNetCore.Mvc;
using NEO.Api.Queries;
using System.Threading.Tasks;

namespace NEO.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/wallets")]
    public class WalletController : ControllerBase
    {
        [HttpGet("{address}")]
        public async Task<IActionResult> Get([FromServices]IMediator mediator, string address)
        {
            return Ok(await mediator.Send(new GetWalletResumeByAddressQuery(address)));
        }
    }
}
