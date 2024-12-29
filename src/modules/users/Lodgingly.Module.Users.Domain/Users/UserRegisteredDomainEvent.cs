using Lodgingly.Framework.Domain.Events;

namespace Lodgingly.Module.Users.Domain.Users;

public sealed class UserRegisteredDomainEvent(Guid userId) : DomainEvent
{
    public Guid UserId { get; init; } = userId;
}