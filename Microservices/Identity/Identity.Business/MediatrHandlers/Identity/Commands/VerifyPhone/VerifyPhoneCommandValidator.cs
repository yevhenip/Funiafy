using FluentValidation;

namespace Identity.Business.MediatrHandlers.Identity.Commands.VerifyPhone
{
    public class VerifyPhoneCommandValidator : AbstractValidator<VerifyPhoneCommand>
    {
        public VerifyPhoneCommandValidator()
        {
            RuleFor(r => r.Dto.Email).EmailAddress()
                .WithMessage("Provide Email Address");

            RuleFor(r => r.Dto.VerifyToken).NotEmpty()
                .WithMessage("Provide verification token");

            RuleFor(r => r.Dto.Phone).Matches(
                    "\\+(9[976]\\d|8[987530]\\d|6[987]\\d|5[90]\\d|42\\d|3[875]\\d|2[98654321]\\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|4[987654310]|3[9643210]|2[70]|7|1)\\d{1,14}$")
                .WithMessage("Enter correct phone number");
        }
    }
}