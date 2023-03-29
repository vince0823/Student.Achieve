using Fabricdot.Infrastructure.Commands;
using Student.Achieve.Infrastructure.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Authentication
{
    internal class RefreshTokenCommandHandler : CommandHandler<RefreshTokenCommand, JwtTokenValue>
    {
        private readonly IJwtSecurityTokenService _jwtSecurityTokenService;

        public RefreshTokenCommandHandler(IJwtSecurityTokenService jwtSecurityTokenService)
        {
            _jwtSecurityTokenService = jwtSecurityTokenService;
        }

        public override async Task<JwtTokenValue> ExecuteAsync(
            RefreshTokenCommand command,
            CancellationToken cancellationToken)
        {
            return await _jwtSecurityTokenService.RefreshTokenAsync(
                command.AccessToken,
                command.RefreshToken);
        }
    }
}