using FluentValidation;

namespace Identity.Business.MediatrHandlers.Identity.Commands.ChangePassword
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(r => r.Dto.Email).EmailAddress()
                .WithMessage("Enter Email Address");

            RuleFor(r => r.Dto.NewPassword).MinimumLength(10).MaximumLength(20)
                .WithMessage("Password should be between 10 and 20 characters");

            RuleFor(r => r.Dto.NewPassword).Equal(r => r.Dto.PasswordConfirmed)
                .WithMessage("The passwords don't match");

            RuleFor(r => r.Dto.NewPassword).NotEqual(r => r.Dto.OldPassword)
                .WithMessage("Provide new password");
        }
    }
}