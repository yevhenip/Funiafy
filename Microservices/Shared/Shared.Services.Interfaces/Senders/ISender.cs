using Shared.Services.Interfaces.DTO.Application.Messages;

namespace Shared.Services.Interfaces.Senders
{
    public interface ISender<in TMessage> where TMessage : Message
    {
        Task SendAsync(TMessage emailMessage);
    }
}