using Lodgingly.Framework.Application.EventBus;
using Lodgingly.Framework.Application.Messaging.Events;
using Lodgingly.Module.Users.Domain.Users;
using Lodgingly.Module.Users.IntegrationEvents;

namespace Lodgingly.Module.Users.Application.Users.UpdateUser;

internal sealed class UserProfileUpdatedDomainEventHandler(IEventBus eventBus)
    : DomainEventHandler<UserProfileUpdatedDomainEvent>
{
    public override async Task Handle(
        UserProfileUpdatedDomainEvent domainEvent,
        CancellationToken cancellationToken = default)
    {
        await eventBus.PublishAsync(
            new UserProfileUpdatedIntegrationEvent(
                domainEvent.Id,
                domainEvent.HappenedAtUtc,
                domainEvent.UserId,
                domainEvent.FirstName,
                domainEvent.LastName),
            cancellationToken);
    }
}
