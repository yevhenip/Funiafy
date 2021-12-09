namespace Shared.Services.Interfaces.DTO.Identity
{
    public record ChangePasswordDTO
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string PasswordConfirmed { get; set; }
        public string Email { get; set; }
    }
}