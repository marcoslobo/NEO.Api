using Npgsql;
using NEO.Api.Configs;
using NEO.Api.Models;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NEO.Api.Repository
{
    public class BlockRepository : IBlockRepository
    {
        public BlockRepository()        {

        }
        public async Task<IEnumerable<Block>> GetAll()
        {
            using var connection = new NpgsqlConnection(ConnectionsStrings.EvoluaPostgres);

            return await connection.QueryAllAsync<Block>();
        }
    }
}
