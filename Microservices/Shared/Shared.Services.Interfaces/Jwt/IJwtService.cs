using Shared.Services.Interfaces.DTO.Identity;

namespace Shared.Services.Interfaces.Jwt
{
    public interface IJwtService
    {
        Task<string> GenerateJwtToken(UserDTO user, IEnumerable<string> roles);
    }
}