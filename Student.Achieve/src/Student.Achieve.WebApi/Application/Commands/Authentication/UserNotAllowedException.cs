using Fabricdot.Infrastructure.Commands;
using System.Diagnostics.CodeAnalysis;

namespace Student.Achieve.WebApi.Application.Commands.Authentication
{
    [SuppressMessage("Roslynator", "RCS1194:Implement exception constructors.", Justification = "<Pending>")]
    public class UserNotAllowedException : CommandException
    {
        public const int ErrorCode = 902;

        public UserNotAllowedException(string message = "User is not allowed.") : base(message, ErrorCode)
        {
        }
    }
}