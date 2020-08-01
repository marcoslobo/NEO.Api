using MediatR;
using NEO.Api.Models;
using System.Collections.Generic;

namespace NEO.Api.Queries
{
    public class GetAllBlocksQuery : IRequest<IEnumerable<Block>>
    {
    }
}
