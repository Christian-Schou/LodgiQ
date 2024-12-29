using Lodgingly.Framework.Domain.Results;

namespace Lodgingly.Framework.Application.Authroization;

public interface IPermissionService
{
    Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string userId);
}