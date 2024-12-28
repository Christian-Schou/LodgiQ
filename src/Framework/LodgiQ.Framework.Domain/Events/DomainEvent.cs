namespace LodgiQ.Framework.Domain.Events;

public abstract class DomainEvent : IDomainEvent
{
    protected DomainEvent()
    {
        Id = Guid.NewGuid();
        HappenedAtUtc = DateTime.UtcNow;
    }

    protected DomainEvent(Guid id, DateTime happenedAtUtc)
    {
        Id = id;
        HappenedAtUtc = happenedAtUtc;
    }

    public Guid Id { get; }
    public DateTime HappenedAtUtc { get; }
}