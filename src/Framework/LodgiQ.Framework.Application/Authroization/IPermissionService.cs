namespace LodgiQ.Framework.Application.Authroization;

public interface IPermissionService
{
    Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string userId);
}