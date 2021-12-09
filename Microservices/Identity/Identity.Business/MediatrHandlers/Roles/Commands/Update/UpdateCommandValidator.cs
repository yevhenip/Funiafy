using FluentValidation;

namespace Identity.Business.MediatrHandlers.Roles.Commands.Update
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(c => c.Role.Name).NotEmpty()
                .WithMessage("Name is required");
        }
    }
}