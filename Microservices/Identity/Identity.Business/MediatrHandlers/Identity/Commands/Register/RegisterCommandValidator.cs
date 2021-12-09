using System.Text.RegularExpressions;
using FluentValidation;

namespace Identity.Business.MediatrHandlers.Identity.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(r => r.Register.Email).EmailAddress()
                .WithMessage("Enter Email Address");

            RuleFor(r => r.Register.Gender).Matches("^(?:(?:Fem|M)ale|Non-binary)$", RegexOptions.IgnoreCase)
                .WithMessage("Enter male, female or fucking no-binary");

            RuleFor(r => r.Register.Password).MinimumLength(10).MaximumLength(20)
                .WithMessage("Password should be between 10 and 20 characters");

            RuleFor(r => r.Register.Password).Equal(r => r.Register.ConfirmedPassword)
                .WithMessage("The passwords don't match");

            RuleFor(r => r.Register.PhoneNumber).Matches(
                    "\\+(9[976]\\d|8[987530]\\d|6[987]\\d|5[90]\\d|42\\d|3[875]\\d|2[98654321]\\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|4[987654310]|3[9643210]|2[70]|7|1)\\d{1,14}$")
                .WithMessage("Enter correct phone number");

            RuleFor(r => r.Register.UserName).MinimumLength(4).MaximumLength(20)
                .WithMessage("UserName should be between 4 and 20 characters");

            RuleFor(r => r.Register.DateOfBirth).Must(b => b < DateTime.Now && new DateTime(1900, 1, 1) < b)
                .WithMessage("Provide correct birthday");
        }
    }
}