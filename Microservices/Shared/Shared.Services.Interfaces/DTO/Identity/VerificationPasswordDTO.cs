namespace Shared.Services.Interfaces.DTO.Identity
{
    public record VerificationPasswordDTO
    {
        public string Password { get; set; }
        public string PasswordConfirmed { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}