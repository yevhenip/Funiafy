using Application.DTO;
using ApplicationServices.Interfaces.Email;

namespace ApplicationServices.Implementation.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailConfig;

        public EmailSender(EmailSettings emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }
    }
}