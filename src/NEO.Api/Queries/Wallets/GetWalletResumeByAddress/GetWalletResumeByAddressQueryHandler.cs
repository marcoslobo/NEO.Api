using MediatR;
using NEO.Api.Models;
using NEO.Api.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NEO.Api.Queries
{
    public class GetWalletResumeByAddressQueryHandler : IRequestHandler<GetWalletResumeByAddressQuery, WalletByAddressResultDto>
    {
        private readonly IWalletRepository walletRepository;

        public GetWalletResumeByAddressQueryHandler(IWalletRepository walletRepository)
        {
            this.walletRepository = walletRepository ?? throw new ArgumentNullException(nameof(walletRepository));
        }
        public Task<WalletByAddressResultDto> Handle(GetWalletResumeByAddressQuery request, CancellationToken cancellationToken)
        {
            return walletRepository.GetResumeByAddress(request.Address);
        }
    }
}
