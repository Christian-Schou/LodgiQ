using Lodgingly.Framework.Domain.Errors;

namespace Lodgingly.Framework.Application.Exceptions;

public sealed class LodgiQException(string requestName, Error? error = default, Exception? innerException = default)
    : Exception("Application Exception", innerException)
{
    public string RequestName { get; } = requestName;

    public Error? Error { get; } = error;
}