using System.Reflection;
using FluentValidation;
using LodgiQ.Framework.Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace LodgiQ.Framework.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationFramework(
        this IServiceCollection services, Assembly[] moduleAssemblies)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(moduleAssemblies);

            // Register Pipeline Behaviors
            configuration.AddOpenBehavior(typeof(ExceptionHandlingPipelineBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
            configuration.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
        });

        services.AddValidatorsFromAssemblies(moduleAssemblies, includeInternalTypes: true);

        return services;
    }
}