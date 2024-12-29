using System.Security.Claims;
using Lodgingly.Framework.Application.Exceptions;
using Lodgingly.Framework.Infrastructure.Authentication.Claims;

namespace Lodgingly.Framework.Infrastructure.Authentication.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal? principal)
    {
        string? userId = principal?.FindFirst(CustomClaims.Sub)?.Value;

        return Guid.TryParse(userId, out Guid parsedUserId)
            ? parsedUserId
            : throw new LodgiQException("User identifier is not available in claims");
    }

    public static string GetIdentityId(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
               throw new LodgiQException("User identity is not available in claims");
    }

    public static HashSet<string> GetPermissions(this ClaimsPrincipal? principal)
    {
        IEnumerable<Claim> permissionClaims = principal?.FindAll(CustomClaims.Permission) ??
                                              throw new LodgiQException("Permissions are not available in claims");

        return permissionClaims.Select(claim => claim.Value).ToHashSet();
    }
}