using NEO.Api.Models;
using System.Threading.Tasks;

namespace NEO.Api.Repositories
{
    public interface IWalletRepository
    {
        Task<WalletByAddressResultDto> GetResumeByAddress(string address);
    }
}
