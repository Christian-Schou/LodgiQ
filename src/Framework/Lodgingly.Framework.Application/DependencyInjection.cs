using System.Reflection;
using FluentValidation;
using Lodgingly.Framework.Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace Lodgingly.Framework.Application;

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