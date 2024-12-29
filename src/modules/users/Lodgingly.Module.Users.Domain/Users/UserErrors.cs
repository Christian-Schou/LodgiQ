using Lodgingly.Framework.Domain.Errors;

namespace Lodgingly.Module.Users.Domain.Users;

public static class UserErrors
{
    public static Error NotFound(Guid userId) =>
        Error.NotFound("Users.NotFound", $"The user with id: {userId} was not found");
    
    public static Error NotFound(string identityId) =>
        Error.NotFound("Users.NotFound", $"The user with IDP id: {identityId} was not found");
}