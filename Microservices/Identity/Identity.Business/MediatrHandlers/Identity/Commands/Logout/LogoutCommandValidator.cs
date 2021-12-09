using FluentValidation;

namespace Identity.Business.MediatrHandlers.Identity.Commands.Logout
{
    public class LogoutCommandValidator : AbstractValidator<LogoutCommand>
    {
        public LogoutCommandValidator()
        {
            RuleFor(rp => rp.Email).NotEmpty();
        }
    }
}