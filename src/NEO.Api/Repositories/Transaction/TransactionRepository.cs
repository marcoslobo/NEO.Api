using Dapper;
using NEO.Api.Configs;
using NEO.Api.Models;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace NEO.Api.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public TransactionRepository() 
        {

        }

        public async Task<PaginationBaseDto<GetAllTransactionsResultDto>> GetAll(int registersNumber, int registersIgnored)
        {
            using var connection = new NpgsqlConnection(ConnectionsStrings.EvoluaPostgres); 

            var result = new PaginationBaseDto<GetAllTransactionsResultDto>()
            {
                Items = await connection.QueryAsync<GetAllTransactionsResultDto>
                (
                    @$"SELECT 
                          id,
                          hash,
                          type
                      FROM transactions 
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

        public async Task<TransactionByHashResultDto> GetDetailByHash(string hash) 
        {
            using var connection = new NpgsqlConnection(ConnectionsStrings.EvoluaPostgres);

            var query = @"SELECT 
                             t.hash, 
                             b.time,
                             t.net_fee AS NetworkFee, 
                             t.sys_fee AS SystemFee, 
                             t.size, 
                             t.block_id AS BlockId
                          FROM 
                             transactions t 
                             INNER JOIN blocks b on b.index = t.block_id
                          WHERE 
                             t.hash = @hash";

            return await connection.QueryFirstOrDefaultAsync<TransactionByHashResultDto>(query, new { hash });  
        }
    }
}
