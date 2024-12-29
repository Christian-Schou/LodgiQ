using Dapper;
using Lodgingly.Framework.Application.Caching;
using Lodgingly.Framework.Application.Clock;
using Lodgingly.Framework.Application.Data;
using Lodgingly.Framework.Application.EventBus;
using Lodgingly.Framework.Infrastructure.Authentication.Extensions;
using Lodgingly.Framework.Infrastructure.Authorization;
using Lodgingly.Framework.Infrastructure.Caching;
using Lodgingly.Framework.Infrastructure.Clock;
using Lodgingly.Framework.Infrastructure.Data;
using Lodgingly.Framework.Infrastructure.Messaging.Outbox;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Quartz;
using StackExchange.Redis;

namespace Lodgingly.Framework.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureFramework(
        this IServiceCollection services,
        string serviceName,
        Action<IRegistrationConfigurator>[] moduleConsumersToConfigure,
        string databaseConnectionString,
        string redisConnectionString)
    {
        // Authentication/Authorization
        services.AddCustomAuthentication();
        services.AddCustomAuthorization();
        
        // Framework Services
        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.TryAddSingleton<IEventBus, EventBus.EventBus>();
        services.TryAddSingleton<InsertOutboxMessagesInterceptor>();
        
        // Database
        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);
        services.TryAddScoped<IDatabaseConnectionFactory, DatabaseConnectionFactory>();
        SqlMapper.AddTypeHandler(new GenericArrayHandler<string>());
        
        // Background Job Services
        services.AddQuartz(configurator =>
        {
            var scheduler = Guid.NewGuid();
            configurator.SchedulerId = $"default-id-{scheduler}";
            configurator.SchedulerName = $"default-name-{scheduler}";
        });
        services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);
        
        // Redis Distributed Cache Services
        try
        {
            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
            services.AddSingleton(connectionMultiplexer);
            services.AddStackExchangeRedisCache(options =>
                options.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer));
        }
        catch
        {
            services.AddDistributedMemoryCache();
        }
        services.TryAddSingleton<ICacheService, CacheService>();
        
        // Messaging Services
        services.AddMassTransit(configuration =>
        {
            foreach (Action<IRegistrationConfigurator> consumer in moduleConsumersToConfigure)
            {
                consumer(configuration);
            }
            
            configuration.SetKebabCaseEndpointNameFormatter();
            
            configuration.UsingInMemory((context, config) =>
            {
                config.ConfigureEndpoints(context);
            });
        });
        
        // Telemetry Services
        services
            .AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(serviceName))
            .WithTracing(tracing =>
            {
                tracing
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddEntityFrameworkCoreInstrumentation()
                    .AddRedisInstrumentation()
                    .AddNpgsql()
                    .AddSource(MassTransit.Logging.DiagnosticHeaders.DefaultListenerName);

                tracing.AddOtlpExporter();
            });

        return services;
    }
}