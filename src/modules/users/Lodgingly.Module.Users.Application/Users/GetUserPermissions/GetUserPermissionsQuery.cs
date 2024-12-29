using Lodgingly.Framework.Application.Authroization;
using Lodgingly.Framework.Application.Messaging.Queries;

namespace Lodgingly.Module.Users.Application.Users.GetUserPermissions;

public sealed record GetUserPermissionsQuery(string IdentityId) : IQuery<PermissionsResponse>;