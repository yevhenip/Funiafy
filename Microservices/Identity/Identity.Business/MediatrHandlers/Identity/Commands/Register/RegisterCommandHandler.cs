using AutoMapper;
using Identity.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Services.Implementation.Settings;
using Shared.Services.Interfaces.DTO.Application.Messages;
using Shared.Services.Interfaces.Senders;

namespace Identity.Business.MediatrHandlers.Identity.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IEmailSender _emailSender;
        private readonly EmailTemplates _emailTemplates;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public RegisterCommandHandler(UserManager<User> userManager, IEmailSender emailSender, IMapper mapper,
            EmailTemplates emailTemplates)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _mapper = mapper;
            _emailTemplates = emailTemplates;
        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.Register);
            user.Id = Guid.NewGuid().ToString();

            var result = await _userManager.CreateAsync(user, request.Register.Password);
            if (result.Succeeded)
                await ConfigureVerificationToken(user);
            else
                throw new ApplicationException(string.Join(", ", result.Errors.Select(e => e.Description)));

            return Unit.Value;
        }

        private async Task ConfigureVerificationToken(User user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var url = $"https://localhost:7193/api/v1/Identity/{user.Email}/{token}";
            var email = _emailTemplates.VerificationEmail;

            await _emailSender.SendAsync(new EmailMessage(new[] { user.Email }, "Verification Code",
                email.Replace("{apiUrl}", url)));
        }
    }
}