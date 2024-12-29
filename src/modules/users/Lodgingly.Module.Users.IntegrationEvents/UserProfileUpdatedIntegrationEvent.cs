using Lodgingly.Framework.Application.EventBus;

namespace Lodgingly.Module.Users.IntegrationEvents;

public sealed class UserProfileUpdatedIntegrationEvent : IntegrationEvent
{
    public UserProfileUpdatedIntegrationEvent(
        Guid id,
        DateTime happenedAtUtc,
        Guid userId,
        string firstName,
        string lastName) : base(id, happenedAtUtc)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
    }
    
    public Guid UserId { get; init; }
    
    public string FirstName { get; init; }
    
    public string LastName { get; init; }
}