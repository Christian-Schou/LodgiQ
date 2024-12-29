namespace Lodgingly.Framework.Infrastructure.Messaging.Inbox;

public sealed class InboxMessage
{
    public Guid Id { get; init; }
    
    public string Type { get; init; }
    
    public string Content { get; init; }
    
    public DateTime HappenedAtUtc { get; init; }
    
    public DateTime ProcessedAtUtc { get; init; }
    
    public string? Error { get; init; }
}