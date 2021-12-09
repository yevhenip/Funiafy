namespace Shared.Services.Interfaces.DTO.Identity
{
    public record RegisterDTO
    {
        public string UserName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string ConfirmedPassword { get; init; }
        public string PhoneNumber { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string Gender { get; init; }
    }
}