namespace Lodgingly.Framework.Application.EventBus;

public interface IIntegrationEvent
{
    Guid Id { get; }

    DateTime HappenedAtUtc { get; }
}