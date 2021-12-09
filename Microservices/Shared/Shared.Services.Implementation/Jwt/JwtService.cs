using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared.Services.Implementation.Settings;
using Shared.Services.Interfaces.DTO.Identity;
using Shared.Services.Interfaces.Jwt;

namespace Shared.Services.Implementation.Jwt
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public Task<string> GenerateJwtToken(UserDTO user, IEnumerable<string> roles)
        {
            List<Claim> claims = new()
            {
                new Claim("Id", user.Id),
                new Claim("UserName", user.UserName),
                new Claim("Email", user.Email)
            };
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var jwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                    SecurityAlgorithms.HmacSha256Signature));

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(jwtToken));
        }
    }
}