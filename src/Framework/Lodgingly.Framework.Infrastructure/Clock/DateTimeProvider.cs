using Lodgingly.Framework.Application.Clock;

namespace Lodgingly.Framework.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}