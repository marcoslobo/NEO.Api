using NEO.Api.Models;
using System.Threading.Tasks;

namespace NEO.Api.Repositories
{
    public interface ITransactionRepository
    {
        Task<TransactionByHashResultDto> GetDetailByHash(string hash);    
    }
}
