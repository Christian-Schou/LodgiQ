using FluentValidation;

namespace Lodgingly.Module.Users.Application.Users.UpdateUser;

internal sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(usc => usc.UserId).NotEmpty();
        RuleFor(usc => usc.FirstName).NotEmpty();
        RuleFor(usc => usc.LastName).NotEmpty();
    }
}