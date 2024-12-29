namespace Lodgingly.Framework.Domain.Errors;

/// <summary>
///     Represents an error with a specific code, description, and type.
/// </summary>
public record Error
{
    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="Error" /> class.
    /// </summary>
    /// <param name="code">The unique code identifying the error.</param>
    /// <param name="description">A description of the error.</param>
    /// <param name="type">The type of the error.</param>
    public Error(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description;
        Type = type;
    }

    #endregion

    #region Static Fields

    /// <summary>
    ///     Represents the absence of an error.
    /// </summary>
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);

    /// <summary>
    ///     Represents an error indicating a null value was provided.
    /// </summary>
    public static readonly Error NullValue = new("General.Null", "Null value was provided", ErrorType.Failure);

    #endregion

    #region Properties

    /// <summary>
    ///     Gets the unique code identifying the error.
    /// </summary>
    public string Code { get; }

    /// <summary>
    ///     Gets the description of the error.
    /// </summary>
    public string Description { get; }

    /// <summary>
    ///     Gets the type of the error.
    /// </summary>
    public ErrorType Type { get; }

    #endregion

    #region Methods

    /// <summary>
    ///     Creates a failure error with the specified code and description.
    /// </summary>
    /// <param name="code">The unique code identifying the error.</param>
    /// <param name="description">A description of the error.</param>
    /// <returns>An <see cref="Error" /> instance representing a failure.</returns>
    public static Error Failure(string code, string description)
    {
        return new Error(code, description, ErrorType.Failure);
    }

    /// <summary>
    ///     Creates a not found error with the specified code and description.
    /// </summary>
    /// <param name="code">The unique code identifying the error.</param>
    /// <param name="description">A description of the error.</param>
    /// <returns>An <see cref="Error" /> instance representing a not found error.</returns>
    public static Error NotFound(string code, string description)
    {
        return new Error(code, description, ErrorType.NotFound);
    }

    /// <summary>
    ///     Creates a problem error with the specified code and description.
    /// </summary>
    /// <param name="code">The unique code identifying the error.</param>
    /// <param name="description">A description of the error.</param>
    /// <returns>An <see cref="Error" /> instance representing a problem.</returns>
    public static Error Problem(string code, string description)
    {
        return new Error(code, description, ErrorType.Problem);
    }

    /// <summary>
    ///     Creates a conflict error with the specified code and description.
    /// </summary>
    /// <param name="code">The unique code identifying the error.</param>
    /// <param name="description">A description of the error.</param>
    /// <returns>An <see cref="Error" /> instance representing a conflict.</returns>
    public static Error Conflict(string code, string description)
    {
        return new Error(code, description, ErrorType.Conflict);
    }

    #endregion
}