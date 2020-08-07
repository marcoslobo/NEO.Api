using Dapper;
using NEO.Api.Configs;
using NEO.Api.Models;
using Npgsql;
using System.Threading.Tasks;

namespace NEO.Api.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
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
