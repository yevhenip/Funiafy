using FluentValidation;

namespace Identity.Business.MediatrHandlers.Users.Commands.RemoveFromRole
{
    public class RemoveFromRoleCommandValidator : AbstractValidator<RemoveFromRoleCommand>
    {
        public RemoveFromRoleCommandValidator()
        {
            RuleFor(rr => rr.Role).NotEmpty()
                .WithMessage("Role is required");

            RuleFor(rr => rr.UserId).NotEmpty()
                .WithMessage("User id is required");
        }
    }
}