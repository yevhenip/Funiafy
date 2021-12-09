using FluentValidation;

namespace Identity.Business.MediatrHandlers.Users.Commands.Delete
{
    public class DeleteCommandValidator : AbstractValidator<DeleteCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(du => du.Id).NotEmpty()
                .WithMessage("User id is required");
        }
    }
}