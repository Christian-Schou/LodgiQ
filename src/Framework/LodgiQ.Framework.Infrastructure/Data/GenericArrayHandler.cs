using System.Data;
using Dapper;

namespace LodgiQ.Framework.Infrastructure.Data;

internal sealed class GenericArrayHandler<TValue> : SqlMapper.TypeHandler<TValue[]>
{
    public override void SetValue(IDbDataParameter parameter, TValue[]? value)
    {
        parameter.Value = value;
    }

    public override TValue[]? Parse(object value)
    {
        return value as TValue[];
    }
}