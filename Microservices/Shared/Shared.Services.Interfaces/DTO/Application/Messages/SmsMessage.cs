namespace Shared.Services.Interfaces.DTO.Application.Messages
{
    public class SmsMessage : Message
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Message { get; set; }
    }
}