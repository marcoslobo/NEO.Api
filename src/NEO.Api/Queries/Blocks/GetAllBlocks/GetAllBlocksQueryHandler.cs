using MediatR;
using NEO.Api.Models;
using NEO.Api.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NEO.Api.Queries
{
    public class GetAllBlocksQueryHandler : IRequestHandler<GetAllBlocksQuery, IEnumerable<Block>>
    {
        private readonly IBlockRepository blockRepository;

        public GetAllBlocksQueryHandler(IBlockRepository blockRepository)
        {
            this.blockRepository = blockRepository ?? throw new System.ArgumentNullException(nameof(blockRepository));
        }
        public  Task<IEnumerable<Block>> Handle(GetAllBlocksQuery request, CancellationToken cancellationToken)
        {
            return blockRepository.GetAll();
        }
    }
}
