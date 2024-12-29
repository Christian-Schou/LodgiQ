namespace Lodgingly.Framework.Application.Authroization;

public sealed record PermissionsResponse(Guid UserId, HashSet<string> Permissions);