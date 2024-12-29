using Microsoft.AspNetCore.Authorization;

namespace Lodgingly.Framework.Infrastructure.Authorization;

internal sealed class PermissionRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission { get; } = permission;
}