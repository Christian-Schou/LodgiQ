using Lodgingly.Framework.Domain.Results;

namespace Lodgingly.Framework.Domain.Errors;

public sealed record ValidationError : Error
{
    public ValidationError(Error[] errors)
        : base("General.Validation", "One or more validation errors occured", ErrorType.Validation)
    {
        Errors = errors;
    }

    public Error[] Errors { get; }

    public static ValidationError FromResults(IEnumerable<Result> results)
    {
        return new ValidationError(results.Where(result => result.IsFailure).Select(result => result.Error).ToArray());
    }
}