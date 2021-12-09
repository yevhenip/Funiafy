using Identity.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Services.Implementation.Settings;
using Shared.Services.Interfaces.DTO.Application.Messages;
using Shared.Services.Interfaces.Senders;

namespace Identity.Business.MediatrHandlers.Identity.Commands.ChangePhone
{
    public class ChangePhoneCommandHandler : IRequestHandler<ChangePhoneCommand>
    {
        private readonly SmsNumberSender _smsNumberSender;
        private readonly ISmsSender _smsSender;
        private readonly UserManager<User> _userManager;

        public ChangePhoneCommandHandler(UserManager<User> userManager, ISmsSender smsSender,
            SmsNumberSender smsNumberSender)
        {
            _userManager = userManager;
            _smsSender = smsSender;
            _smsNumberSender = smsNumberSender;
        }

        public async Task<Unit> Handle(ChangePhoneCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            var token = await _userManager.GenerateChangePhoneNumberTokenAsync(user, request.Phone);

            await _smsSender.SendAsync(new SmsMessage
                { To = request.Phone, Message = $"Yours verification code is {token}", From = _smsNumberSender.From });
            return Unit.Value;
        }
    }
}