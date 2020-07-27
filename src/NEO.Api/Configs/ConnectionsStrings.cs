using System;

namespace NEO.Api.Configs
{
    public static class ConnectionsStrings
    {
        public static string EvoluaPostgres = Environment.GetEnvironmentVariable("ConnectionStrings__evolua-postgres");
    }
}
