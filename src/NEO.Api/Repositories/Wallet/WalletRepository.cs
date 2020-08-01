using Dapper;
using NEO.Api.Configs;
using NEO.Api.Models;
using Npgsql;
using System.Threading.Tasks;

namespace NEO.Api.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        public async Task<WalletByAddressResultDto> GetResumeByAddress(string address)
        {
            using var connection = new NpgsqlConnection(ConnectionsStrings.EvoluaPostgres);

            var query = @"SELECT * FROM WALLETS W WHERE W.ADDRESS = @address";

            return await connection.QueryFirstOrDefaultAsync<WalletByAddressResultDto>(query, new { address });
        }
    }
}
