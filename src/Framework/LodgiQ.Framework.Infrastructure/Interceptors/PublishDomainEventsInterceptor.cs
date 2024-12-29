using LodgiQ.Framework.Domain.Entities;
using LodgiQ.Framework.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace LodgiQ.Framework.Infrastructure.Interceptors;

public sealed class PublishDomainEventsInterceptor(IServiceScopeFactory serviceScopeFactory) : SaveChangesInterceptor
{
    public override async ValueTask<int> SavedChangesAsync(
        SaveChangesCompletedEventData eventData,
        int result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
        {
            await PublishDomainEventsAsync(eventData.Context);
        }

        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    private async Task PublishDomainEventsAsync(DbContext context)
    {
        var domainEvents = context
            .ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                IReadOnlyCollection<IDomainEvent> domainEvents = entity.DomainEvents;

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        using IServiceScope serviceScope = serviceScopeFactory.CreateScope();

        IPublisher publisher = serviceScope.ServiceProvider.GetRequiredService<IPublisher>();

        foreach (IDomainEvent domainEvent in domainEvents)
        {
            await publisher.Publish(domainEvent);
        }
    }
}