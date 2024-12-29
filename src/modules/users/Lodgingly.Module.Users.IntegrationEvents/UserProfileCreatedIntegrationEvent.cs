using Lodgingly.Framework.Application.EventBus;

namespace Lodgingly.Module.Users.IntegrationEvents;

public sealed class UserProfileCreatedIntegrationEvent : IntegrationEvent
{
    public UserProfileCreatedIntegrationEvent(
        Guid id,
        DateTime happenedAtUtc,
        Guid userId,
        string email,
        string firstName,
        string lastName) : base(id, happenedAtUtc)
    {
        UserId = userId;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }
    
    public Guid UserId { get; init; }
    
    public string Email { get; init; }
    
    public string FirstName { get; init; }
    
    public string LastName { get; init; }
}