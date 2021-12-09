using Shared.Services.Interfaces.DTO.Application.Messages;
using Shared.Services.Interfaces.Senders;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Shared.Services.Implementation.Senders
{
    public class SmsSender : ISmsSender
    {
        private readonly ITwilioRestClient _client;

        public SmsSender(ITwilioRestClient client)
        {
            _client = client;
        }

        public Task SendAsync(SmsMessage smsMessage)
        {
            return MessageResource.CreateAsync(
                new PhoneNumber(smsMessage.To),
                from: new PhoneNumber(smsMessage.From),
                body: smsMessage.Message,
                client: _client);
        }
    }
}