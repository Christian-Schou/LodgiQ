using System.Data.Common;

namespace Lodgingly.Framework.Application.Data;

public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}