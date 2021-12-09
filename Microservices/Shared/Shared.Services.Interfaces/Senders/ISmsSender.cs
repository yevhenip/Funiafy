using Shared.Services.Interfaces.DTO.Application.Messages;

namespace Shared.Services.Interfaces.Senders
{
    public interface ISmsSender : ISender<SmsMessage>
    {
    }
}