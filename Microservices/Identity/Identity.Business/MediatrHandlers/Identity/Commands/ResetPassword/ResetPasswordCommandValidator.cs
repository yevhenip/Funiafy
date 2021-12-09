using FluentValidation;

namespace Identity.Business.MediatrHandlers.Identity.Commands.ResetPassword
{
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(rp => rp.UsernameOrEmail).NotEmpty();
        }
    }
}