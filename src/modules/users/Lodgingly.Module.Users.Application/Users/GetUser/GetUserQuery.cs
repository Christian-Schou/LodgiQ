using Lodgingly.Framework.Application.Messaging.Queries;

namespace Lodgingly.Module.Users.Application.Users.GetUser;

public sealed record GetUserQuery(Guid UserId) : IQuery<UserResponse>;