using Application.DTO;

namespace ApplicationServices.Interfaces.Email
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}