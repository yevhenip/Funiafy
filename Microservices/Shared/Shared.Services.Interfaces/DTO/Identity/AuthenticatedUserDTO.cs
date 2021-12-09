namespace Shared.Services.Interfaces.DTO.Identity
{
    public record AuthenticatedUserDTO(UserDTO User, string Token);
}