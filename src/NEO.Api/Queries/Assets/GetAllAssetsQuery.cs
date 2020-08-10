using MediatR;
using NEO.Api.Extensions;
using NEO.Api.Models;

namespace NEO.Api.Queries
{
    public class GetAllAssetsQuery : PaginationBaseDto, IRequest<Response>
    {
        public GetAllAssetsQuery(int pageNumber, int registersNumber) : base(pageNumber, registersNumber) 
        {

        }
    }
}
