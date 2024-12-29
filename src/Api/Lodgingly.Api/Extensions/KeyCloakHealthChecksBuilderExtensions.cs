using Lodgingly.Framework.Infrastructure.Extensions;

namespace Lodgingly.Api.Extensions;

internal static class KeyCloakHealthChecksBuilderExtensions
{
    private const string KeyCloakHealthCheck = "KeyCloak";
    private const string KeyCloakHealthCheckUrl = "KeyCloak:HealthUrl";

    internal static IHealthChecksBuilder AddKeyCloak(this IHealthChecksBuilder builder, Uri healthUrl)
    {
        builder.AddUrlGroup(healthUrl, HttpMethod.Get, KeyCloakHealthCheck);
        return builder;
    }

    internal static Uri GetKeyCloakHealthCheckUrl(this IConfiguration configuration)
    {
        return new Uri(configuration.GetValueOrThrow<string>(KeyCloakHealthCheckUrl));
    }
}