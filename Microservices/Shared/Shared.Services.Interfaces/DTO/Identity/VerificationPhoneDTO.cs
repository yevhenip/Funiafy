namespace Shared.Services.Interfaces.DTO.Identity
{
    public record VerificationPhoneDTO
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string VerifyToken { get; set; }
    }
}