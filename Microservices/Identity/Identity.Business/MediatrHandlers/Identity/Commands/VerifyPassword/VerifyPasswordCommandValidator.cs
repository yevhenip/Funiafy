using FluentValidation;
using Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace Identity.Business.MediatrHandlers.Identity.Commands.VerifyPassword
{
    public class VerifyPasswordCommandValidator : AbstractValidator<VerifyPasswordCommand>
    {
        public VerifyPasswordCommandValidator(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            User user = new();

            RuleFor(r => r.Dto.Email).EmailAddress()
                .WithMessage("Provide Email Address");

            RuleFor(r => r.Dto.Email).MustAsync(async (email, _) =>
            {
                user = await userManager.FindByEmailAsync(email);

                return true;
            });

            RuleFor(r => r.Dto.Token).NotEmpty()
                .WithMessage("Provide verification token");

            RuleFor(r => r.Dto.Password).MinimumLength(10).MaximumLength(20)
                .WithMessage("Password should be between 10 and 20 characters");

            RuleFor(r => r.Dto.Password).MustAsync(async (password, _) =>
            {
                var result = await signInManager.CheckPasswordSignInAsync(user, password, false);

                return !result.Succeeded;
            }).WithMessage("Provide uniq password");

            RuleFor(r => r.Dto.PasswordConfirmed).Equal(vp => vp.Dto.Password)
                .WithMessage("The passwords don't match");
        }
    }
}