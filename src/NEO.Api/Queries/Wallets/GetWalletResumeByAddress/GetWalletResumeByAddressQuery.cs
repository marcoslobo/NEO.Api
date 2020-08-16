using MediatR;
using NEO.Api.Extensions;

namespace NEO.Api.Queries
{
    public class GetWalletResumeByAddressQuery : IRequest<Response>
    {
        public GetWalletResumeByAddressQuery(string address)
        {
            Address = address;
        }

        public string Address { get; set; }
    }
}
