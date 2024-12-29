using LodgiQ.Framework.Application.Clock;

namespace LodgiQ.Framework.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}