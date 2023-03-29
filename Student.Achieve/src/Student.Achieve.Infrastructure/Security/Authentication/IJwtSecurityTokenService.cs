using System.Security.Claims;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Security.Authentication
{
    public interface IJwtSecurityTokenService
    {
        Task<JwtTokenValue> CreateTokenAsync(ClaimsPrincipal principal);

        Task<JwtTokenValue> RefreshTokenAsync(
            string accessToken,
            string refreshToken);
    }
}