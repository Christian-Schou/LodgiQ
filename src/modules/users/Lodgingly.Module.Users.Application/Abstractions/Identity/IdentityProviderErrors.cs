using Lodgingly.Framework.Domain.Errors;

namespace Lodgingly.Module.Users.Application.Abstractions.Identity;

public static class IdentityProviderErrors
{
    public static readonly Error EmailIsNotUnique = Error.Conflict(
        "Identity.EmailIsNotUnique",
        "The specified email is already in use and not unique.");
}