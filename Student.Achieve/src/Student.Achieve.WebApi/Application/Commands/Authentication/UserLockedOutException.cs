using Fabricdot.Infrastructure.Commands;
using System.Diagnostics.CodeAnalysis;

namespace Student.Achieve.WebApi.Application.Commands.Authentication
{
    [SuppressMessage("Roslynator", "RCS1194:Implement exception constructors.", Justification = "<Pending>")]
    public class UserLockedOutException : CommandException
    {
        public const int ErrorCode = 903;

        public UserLockedOutException(string message = "User is locked out.") : base(message, ErrorCode)
        {
        }
    }
}