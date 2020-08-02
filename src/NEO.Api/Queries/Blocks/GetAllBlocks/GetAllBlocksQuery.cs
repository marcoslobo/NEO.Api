using MediatR;
using NEO.Api.Models;

namespace NEO.Api.Queries
{
    public class GetAllBlocksQuery : PaginationBaseDto, IRequest<PaginationBaseDto<GetAllBlocksResultDto>>
    {
        public GetAllBlocksQuery(int pageNumber, int registersNumber) : base(pageNumber, registersNumber)
        {

        }
    }
}
