namespace Shared.Services.Interfaces.DTO.Identity
{
    public record LoginDTO
    {
        public string EmailOrUsername { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}