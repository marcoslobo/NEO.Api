using MediatR;
using NEO.Api.Extensions;
using NEO.Api.Models;

namespace NEO.Api.Queries
{
    public class GetAllTransactionsQuery : PaginationBaseDto, IRequest<Response>
    {
        public GetAllTransactionsQuery(int pageNumber, int registersNumber) : base(pageNumber, registersNumber)
        {

        }
    }
}
