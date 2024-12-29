using FluentValidation;

namespace Lodgingly.Module.Users.Application.Users.RegisterUser;

internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(ruc => ruc.FirstName).NotEmpty();
        RuleFor(ruc => ruc.LastName).NotEmpty();
        RuleFor(ruc => ruc.Email).EmailAddress();
        RuleFor(ruc => ruc.Password).MinimumLength(6);
    }
}