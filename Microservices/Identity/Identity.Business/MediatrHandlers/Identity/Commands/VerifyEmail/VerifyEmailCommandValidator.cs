using FluentValidation;

namespace Identity.Business.MediatrHandlers.Identity.Commands.VerifyEmail
{
    public class VerifyEmailCommandValidator : AbstractValidator<VerifyEmailCommand>
    {
        public VerifyEmailCommandValidator()
        {
            RuleFor(r => r.Dto.Email).EmailAddress()
                .WithMessage("Enter Email Address");

            RuleFor(r => r.Dto.Token).NotEmpty()
                .WithMessage("Provide verification token");
        }
    }
}