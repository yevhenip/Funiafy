using Identity.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Services.Implementation.Settings;
using Shared.Services.Interfaces.DTO.Application.Messages;
using Shared.Services.Interfaces.Senders;

namespace Identity.Business.MediatrHandlers.Identity.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand>
    {
        private readonly IEmailSender _emailSender;
        private readonly EmailTemplates _emailTemplates;
        private readonly UserManager<User> _userManager;

        public ResetPasswordCommandHandler(UserManager<User> userManager, IEmailSender emailSender,
            EmailTemplates emailTemplates)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _emailTemplates = emailTemplates;
        }

        public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);
            if (user is null)
            {
                user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
                if (user is null) throw new ApplicationException("Account not found");
            }

            await ConfigureResetPasswordToken(user);

            return Unit.Value;
        }

        private async Task ConfigureResetPasswordToken(User user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var url = $"https://localhost:7193/api/v1/Identity/{user.Email}/{token}";
            var email = _emailTemplates.ResetPasswordEmail;

            await _emailSender.SendAsync(new EmailMessage(new[] { user.Email }, "Reset Password",
                email.Replace("{apiUrl}", url)));
        }
    }
}