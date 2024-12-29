using System.Data.Common;

namespace Lodgingly.Framework.Application.Data;

public interface IDatabaseConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}