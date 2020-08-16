using Dapper;
using NEO.Api.Configs;
using NEO.Api.Models;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NEO.Api.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        public async Task<IEnumerable<WalletTransfersResultDto>> GetTransactionsByAddress(string address)
        {
            using var connection = new NpgsqlConnection(ConnectionsStrings.EvoluaPostgres);

            var query = @"select a.hash as assetHash, a.symbol, a.name as assetName, t.amount, '-' as InOut from transfers t
                            inner join wallets w on t.address_from_id = w.id
                            inner join assets a on t.asset_id = a.id 
                            where w.address  = @address
                            union all 
                            select a.hash as assetHash, a.symbol, a.name as assetName, t.amount, '+' as InOut from transfers t
                            inner join wallets w on t.address_to_id = w.id
                            inner join assets a on t.asset_id = a.id 
                            where w.address  = @address";

            return await connection.QueryAsync<WalletTransfersResultDto>(query, new { address });
        }
    }
}
