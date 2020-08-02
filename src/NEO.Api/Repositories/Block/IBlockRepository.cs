using NEO.Api.Models;
using System.Threading.Tasks;

namespace NEO.Api.Repositories
{
    public interface IBlockRepository
    {
        Task<PaginationBaseDto<GetAllBlocksResultDto>> GetAll(int registersNumber, int registersIgnored);
    }
}
