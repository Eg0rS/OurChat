using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using OurChat.JWT.Models;

namespace OurChat.JWT.Service;

public interface IJwtService
{
    JwtSecurityToken GenerateToken(IEnumerable<Claim> authClaims);
    RefreshTokenModel GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
}