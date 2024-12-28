namespace LodgiQ.Framework.Application.EventBus;

public abstract class IntegrationEvent(Guid id, DateTime happenedAtUtc) : IIntegrationEvent
{
    public Guid Id { get; } = id;
    public DateTime HappenedAtUtc { get; } = happenedAtUtc;
}