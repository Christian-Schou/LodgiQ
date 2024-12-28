using System.Data.Common;

namespace LodgiQ.Framework.Application.Data;

public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}