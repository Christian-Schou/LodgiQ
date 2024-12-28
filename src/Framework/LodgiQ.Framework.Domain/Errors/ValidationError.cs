using LodgiQ.Framework.Domain.Results;

namespace LodgiQ.Framework.Domain.Errors;

public sealed record ValidationError : Error
{
    public ValidationError(Error[] errors)
        :base("General.Validation", "One or more validation errors occured", ErrorType.Validation)
    {
        Errors = errors;
    }
    
    public Error[] Errors { get; }

    public static ValidationError FromResults(IEnumerable<Result> results) =>
        new(results.Where(result => result.IsFailure).Select(result => result.Error).ToArray());
}