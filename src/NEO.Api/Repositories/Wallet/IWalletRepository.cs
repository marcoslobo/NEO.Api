using NEO.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NEO.Api.Repositories
{
    public interface IWalletRepository
    {
        Task<IEnumerable<WalletTransfersResultDto>> GetTransactionsByAddress(string address);
    }
}
