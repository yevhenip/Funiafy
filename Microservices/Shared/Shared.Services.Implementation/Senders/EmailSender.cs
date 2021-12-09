using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using Shared.Services.Implementation.Settings;
using Shared.Services.Interfaces.DTO.Application.Messages;
using Shared.Services.Interfaces.Senders;

namespace Shared.Services.Implementation.Senders
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailConfig;

        public EmailSender(EmailSettings emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public async Task SendAsync(EmailMessage message)
        {
            var emailMessage = CreateEmailMessage(message);

            await Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(EmailMessage message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(message.Subject, _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(TextFormat.Html) { Text = message.Content };
            return emailMessage;
        }

        private async Task Send(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                await client.SendAsync(mailMessage);
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }
    }
}