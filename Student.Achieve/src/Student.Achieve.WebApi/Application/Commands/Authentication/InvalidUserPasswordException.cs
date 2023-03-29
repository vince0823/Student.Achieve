using Fabricdot.Infrastructure.Commands;
using System.Diagnostics.CodeAnalysis;

namespace Student.Achieve.WebApi.Application.Commands.Authentication
{
    [SuppressMessage("Roslynator", "RCS1194:Implement exception constructors.", Justification = "<Pending>")]
    public class InvalidUserPasswordException : CommandException
    {
        public const int ErrorCode = 904;

        public InvalidUserPasswordException(string message = "User password is incorrect.") : base(message, ErrorCode)
        {
        }
    }
}