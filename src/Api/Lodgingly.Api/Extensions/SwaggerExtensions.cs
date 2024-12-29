using Microsoft.OpenApi.Models;

namespace Lodgingly.Api.Extensions;

internal static class SwaggerExtensions
{
    internal static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Lodgingly API",
                Version = "v1",
                Description =
                    "Lodgingly is a smart, efficient, and user-friendly hotel management system built with .NET"
            });

            options.CustomSchemaIds(type => type.FullName?.Replace("+", "."));
        });

        return services;
    }
}