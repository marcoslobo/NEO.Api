using MediatR;
using NEO.Api.Extensions;
using NEO.Api.Models;
using NEO.Api.Repositories;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NEO.Api.Queries
{
    public class GetWalletResumeByAddressQueryHandler : IRequestHandler<GetWalletResumeByAddressQuery, Response>
    {
        private readonly IWalletRepository walletRepository;

        public GetWalletResumeByAddressQueryHandler(IWalletRepository walletRepository)
        {
            this.walletRepository = walletRepository ?? throw new ArgumentNullException(nameof(walletRepository));
        }
        public async Task<Response> Handle(GetWalletResumeByAddressQuery request, CancellationToken cancellationToken)
        {


            var result = new WalletByAddressResultDto() { Address = request.Address };

            var resultFromRepository = await walletRepository.GetTransactionsByAddress(request.Address);

            foreach (var itemResultFromRepository in resultFromRepository.GroupBy(a => a.AssetHash))
            {

                var toPlus = itemResultFromRepository.Where(a => a.InOut == '+').Sum(b => b.Amount);
                var toMinus = itemResultFromRepository.Where(a => a.InOut == '-').Sum(b => b.Amount);

                var assetValueToAdd = new WalletAssetValueDto();
                assetValueToAdd.AssetName = itemResultFromRepository.FirstOrDefault()?.AssetName;
                assetValueToAdd.AssetHash = itemResultFromRepository.Key;
                assetValueToAdd.Value = toPlus - toMinus;
                assetValueToAdd.AssetSymbol = itemResultFromRepository.FirstOrDefault()?.Symbol;

                result.AssetsValues.Add(assetValueToAdd);

            }

            return new Response(result);
        }
    }
}

