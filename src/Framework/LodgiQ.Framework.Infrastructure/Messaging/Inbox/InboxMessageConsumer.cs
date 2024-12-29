namespace LodgiQ.Framework.Infrastructure.Messaging.Inbox;

public class InboxMessageConsumer(Guid inboxMessageId, string name)
{
    public Guid InboxMessageId { get; init; } = inboxMessageId;

    public string Name { get; init; } = name;
}