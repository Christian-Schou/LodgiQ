using System.Data.Common;
using LodgiQ.Framework.Application.Data;
using Npgsql;

namespace LodgiQ.Framework.Infrastructure.Data;

internal sealed class DatabaseConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await dataSource.OpenConnectionAsync();
    }
}