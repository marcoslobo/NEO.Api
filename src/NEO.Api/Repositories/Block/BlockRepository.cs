using Dapper;
using NEO.Api.Configs;
using NEO.Api.Models;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace NEO.Api.Repositories
{
    public class BlockRepository : IBlockRepository
    {
        public BlockRepository()
        {

        }
        public async Task<PaginationBaseDto<GetAllBlocksResultDto>> GetAll(int registersNumber, int registersIgnored)
        {
            using var connection = new NpgsqlConnection(ConnectionsStrings.EvoluaPostgres);

            var result = new PaginationBaseDto<GetAllBlocksResultDto>()
            {
                Items = await connection.QueryAsync<GetAllBlocksResultDto>($"SELECT * FROM BLOCKS ORDER BY INDEX OFFSET {registersIgnored} ROWS FETCH NEXT {registersNumber} ROWS ONLY")
            };

            result.ItensTotal = await connection.QueryFirstOrDefaultAsync<long>($"SELECT COUNT(*) FROM BLOCKS ");


            result.PagesTotal = (int)Math.Ceiling((double)result.ItensTotal / registersNumber);

            return result;
        }
    }
}
