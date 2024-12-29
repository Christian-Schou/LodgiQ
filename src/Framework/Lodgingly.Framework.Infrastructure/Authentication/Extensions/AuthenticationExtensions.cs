using Lodgingly.Framework.Infrastructure.Authentication.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Lodgingly.Framework.Infrastructure.Authentication.Extensions;

internal static class AuthenticationExtensions
{
    internal static IServiceCollection AddAuthenticationInternal(this IServiceCollection services)
    {
        services.AddAuthorization();

        services.AddAuthentication().AddJwtBearer();

        services.AddHttpContextAccessor();

        services.ConfigureOptions<JwtBearerConfigurationOptions>();

        return services;
    }
}