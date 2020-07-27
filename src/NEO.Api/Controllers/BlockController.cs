using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NEO.Api.Models;
using NEO.Api.Repository;

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
        public async Task<IActionResult> Get([FromServices]IBlockRepository blockRepository)
        {
            
            return Ok(await blockRepository.GetAll());
        }
    }
}
