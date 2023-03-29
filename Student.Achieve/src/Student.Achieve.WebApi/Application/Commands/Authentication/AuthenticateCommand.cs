using Fabricdot.Infrastructure.Commands;
using Student.Achieve.Infrastructure.Security.Authentication;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.Authentication
{
    public class AuthenticateCommand : Command<JwtTokenValue>
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}