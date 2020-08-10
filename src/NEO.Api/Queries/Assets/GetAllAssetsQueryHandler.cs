using MediatR;
using NEO.Api.Extensions;
using NEO.Api.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NEO.Api.Queries
{
    public class GetAllAssetsQueryHandler : IRequestHandler<GetAllAssetsQuery, Response> 
    {
        private readonly IAssetRepository assetRepository; 

        public GetAllAssetsQueryHandler(IAssetRepository assetRepository) 
        {
            this.assetRepository = assetRepository ?? throw new ArgumentNullException(nameof(assetRepository));
        }
         
        public async Task<Response> Handle(GetAllAssetsQuery request, CancellationToken cancellationToken)
        {
            var result = await assetRepository.GetAll(request.RegistersNumber, request.RegistersIgnored);

            return new Response(result);
        }
    }
}
