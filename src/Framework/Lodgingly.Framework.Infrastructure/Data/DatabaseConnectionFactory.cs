using System.Data.Common;
using Lodgingly.Framework.Application.Data;
using Npgsql;

namespace Lodgingly.Framework.Infrastructure.Data;

internal sealed class DatabaseConnectionFactory(NpgsqlDataSource dataSource) : IDatabaseConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await dataSource.OpenConnectionAsync();
    }
}