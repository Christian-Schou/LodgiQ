using System.Collections.Concurrent;
using System.Reflection;
using LodgiQ.Framework.Application.EventBus;
using Microsoft.Extensions.DependencyInjection;

namespace LodgiQ.Framework.Infrastructure.Messaging.Inbox;

public static class IntegrationEventHandlersFactory
{
    private static readonly ConcurrentDictionary<string, Type[]> HandlersDictionary = new();

    public static IEnumerable<IIntegrationEventHandler> GetHandlers(
        Type type,
        IServiceProvider serviceProvider,
        Assembly assembly)
    {
        Type[] integrationEventHandlerTypes = HandlersDictionary.GetOrAdd(
            $"{assembly.GetName().Name}-{type.Name}",
            _ =>
            {
                Type[] integrationEventHandlers = assembly.GetTypes()
                    .Where(x => x.IsAssignableTo(typeof(IIntegrationEventHandler<>).MakeGenericType(type)))
                    .ToArray();

                return integrationEventHandlers;
            });

        List<IIntegrationEventHandler> handlers = [];

        foreach (Type integrationEventHandlerType in integrationEventHandlerTypes)
        {
            object integrationEventHandler = serviceProvider.GetRequiredService(integrationEventHandlerType);
            
            handlers.Add((integrationEventHandler as IIntegrationEventHandler)!);
        }

        return handlers;
    }
}