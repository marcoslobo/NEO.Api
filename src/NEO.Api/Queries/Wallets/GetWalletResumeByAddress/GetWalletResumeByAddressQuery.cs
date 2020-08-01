using MediatR;
using NEO.Api.Models;

namespace NEO.Api.Queries
{
    public class GetWalletResumeByAddressQuery : IRequest<WalletByAddressResultDto>
    {
        public GetWalletResumeByAddressQuery(string address)
        {
            Address = address;
        }

        public string Address { get; set; }
    }
}
