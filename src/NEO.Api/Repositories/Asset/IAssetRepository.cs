using NEO.Api.Models;
using System.Threading.Tasks;

namespace NEO.Api.Repositories
{
    public interface IAssetRepository
    { 
        Task<PaginationBaseDto<GetAllAssetsResultDto>> GetAll(int registersNumber, int registersIgnored);
    }
}
