using MimeKit;

namespace Shared.Services.Interfaces.DTO.Application.Messages
{
    public class EmailMessage : Message
    {
        public EmailMessage(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(x => new MailboxAddress(subject, x)));
            Subject = subject;
            Content = content;
        }

        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}