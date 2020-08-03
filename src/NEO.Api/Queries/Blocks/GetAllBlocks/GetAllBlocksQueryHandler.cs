using MediatR;
using NEO.Api.Extensions;
using NEO.Api.Models;
using NEO.Api.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace NEO.Api.Queries
{
    public class GetAllBlocksQueryHandler : IRequestHandler<GetAllBlocksQuery, Response>
    {
        private readonly IBlockRepository blockRepository;

        public GetAllBlocksQueryHandler(IBlockRepository blockRepository)
        {
            this.blockRepository = blockRepository ?? throw new System.ArgumentNullException(nameof(blockRepository));
        }
        public async Task<Response> Handle(GetAllBlocksQuery request, CancellationToken cancellationToken)
        {
            var result = await blockRepository.GetAll(request.RegistersNumber, request.RegistersIgnored);

            return new Response(result);
        }
    }
}
