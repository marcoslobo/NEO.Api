using MediatR;
using NEO.Api.Extensions;
using NEO.Api.Models;

namespace NEO.Api.Queries
{
    public class GetAllBlocksQuery : PaginationBaseDto, IRequest<Response>
    {
        public GetAllBlocksQuery(int pageNumber, int registersNumber) : base(pageNumber, registersNumber)
        {

        }
    }
}
