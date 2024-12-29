using Lodgingly.Framework.Application.EventBus;
using Lodgingly.Framework.Application.Exceptions;
using Lodgingly.Framework.Application.Messaging.Events;
using Lodgingly.Framework.Domain.Results;
using Lodgingly.Module.Users.Application.Users.GetUser;
using Lodgingly.Module.Users.Domain.Users;
using Lodgingly.Module.Users.IntegrationEvents;
using MediatR;

namespace Lodgingly.Module.Users.Application.Users.RegisterUser;

internal sealed class UserRegisteredDomainEventHandler(ISender sender, IEventBus bus)
    : DomainEventHandler<UserRegisteredDomainEvent>
{
    public override async Task Handle(UserRegisteredDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        Result<UserResponse> result = await sender.Send(request: new GetUserQuery(domainEvent.UserId), cancellationToken);

        if (result.IsFailure)
        {
            throw new LodginglyException(nameof(GetUserQuery), result.Error);
        }

        await bus.PublishAsync(
            new UserProfileCreatedIntegrationEvent(
                domainEvent.Id,
                domainEvent.HappenedAtUtc,
                result.Value.Id,
                result.Value.Email,
                result.Value.FirstName,
                result.Value.LastName),
            cancellationToken);
    }
}