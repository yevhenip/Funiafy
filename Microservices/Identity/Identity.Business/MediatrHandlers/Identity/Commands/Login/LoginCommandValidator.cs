using FluentValidation;

namespace Identity.Business.MediatrHandlers.Identity.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(r => r.Login.EmailOrUsername).NotEmpty()
                .WithMessage("Enter email or Username");

            RuleFor(r => r.Login.Password).NotEmpty()
                .WithMessage("Enter Password");
        }
    }
}