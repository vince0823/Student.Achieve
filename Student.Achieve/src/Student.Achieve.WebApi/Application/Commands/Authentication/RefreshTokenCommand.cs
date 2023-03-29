using Fabricdot.Infrastructure.Commands;
using Student.Achieve.Infrastructure.Security.Authentication;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.Authentication
{
    public class RefreshTokenCommand : Command<JwtTokenValue>
    {
        [Required]
        public string AccessToken { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}