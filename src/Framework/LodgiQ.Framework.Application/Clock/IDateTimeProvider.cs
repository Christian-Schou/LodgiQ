namespace LodgiQ.Framework.Application.Clock;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}