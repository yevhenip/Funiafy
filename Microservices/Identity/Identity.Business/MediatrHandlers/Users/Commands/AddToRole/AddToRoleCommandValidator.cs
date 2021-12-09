using FluentValidation;

namespace Identity.Business.MediatrHandlers.Users.Commands.AddToRole
{
    public class AddToRoleCommandValidator : AbstractValidator<AddToRoleCommand>
    {
        public AddToRoleCommandValidator()
        {
            RuleFor(ar => ar.Role).NotEmpty()
                .WithMessage("Role is required");

            RuleFor(ar => ar.UserId).NotEmpty()
                .WithMessage("User id is required");
        }
    }
}