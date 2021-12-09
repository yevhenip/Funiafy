using FluentValidation;

namespace Identity.Business.MediatrHandlers.Roles.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty()
                .WithMessage("Name is required");
        }
    }
}