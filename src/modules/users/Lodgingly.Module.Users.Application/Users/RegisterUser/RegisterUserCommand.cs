using Lodgingly.Framework.Application.Messaging.Commands;

namespace Lodgingly.Module.Users.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(string Email, string Password, string FirstName, string LastName) : ICommand<Guid>;