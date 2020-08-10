using Dapper;
using NEO.Api.Configs;
using NEO.Api.Models;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace NEO.Api.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        public AssetRepository() 
        {

        }

        public async Task<PaginationBaseDto<GetAllAssetsResultDto>> GetAll(int registersNumber, int registersIgnored)
        {
            using var connection = new NpgsqlConnection(ConnectionsStrings.EvoluaPostgres);

            var result = new PaginationBaseDto<GetAllAssetsResultDto>()
            {
                Items = await connection.QueryAsync<GetAllAssetsResultDto> 
                (
                    @$"SELECT 
                          id,
                          name,
                          type
                          amount,
                          issued,
                          type
                      FROM 
                          assets a
                      INNER JOIN 
                          wallets w
                      ON
                          a.
                      ORDER BY 
                          id 
                      OFFSET 
                          {registersIgnored} 
                      ROWS FETCH NEXT  
                          {registersNumber} 
                      ROWS ONLY"
                )
            };

            result.ItensTotal = await connection.QueryFirstOrDefaultAsync<long>(@"SELECT COUNT(*) FROM transactions ");


            result.PagesTotal = (int)Math.Ceiling((double)result.ItensTotal / registersNumber);

            return result;
        }
    }
}
