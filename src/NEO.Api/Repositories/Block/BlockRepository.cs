using Dapper;
using NEO.Api.Configs;
using NEO.Api.Models;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NEO.Api.Repositories
{
    public class BlockRepository : IBlockRepository
    {
        public BlockRepository()
        {

        }
        public async Task<IEnumerable<Block>> GetAll()
        {
            using var connection = new NpgsqlConnection(ConnectionsStrings.EvoluaPostgres);

            return await connection.QueryAsync<Block>("SELECT * FROM BLOCKS");
        }
    }
}
