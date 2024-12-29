using Lodgingly.Framework.Domain.Results;

namespace Lodgingly.Module.Users.Application.Abstractions.Identity;

public interface IIdentityProviderService
{
    Task<Result<string>> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default);
}