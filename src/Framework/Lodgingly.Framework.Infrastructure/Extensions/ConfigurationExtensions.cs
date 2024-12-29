using Microsoft.Extensions.Configuration;

namespace Lodgingly.Framework.Infrastructure.Extensions;

public static class ConfigurationExtensions
{
    public static string GetConnectionStringOrThrow(this IConfiguration configuration, string name)
    {
        return configuration.GetConnectionString(name) ??
               throw new InvalidOperationException($"The connection string {name} was not found");
    }

    public static TValue GetValueOrThrow<TValue>(this IConfiguration configuration, string name)
    {
        return configuration.GetValue<TValue?>(name) ??
               throw new InvalidOperationException($"The value for: {name} was not found");
    }
}