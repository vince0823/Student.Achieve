using Fabricdot.Domain.SharedKernel;
using System.Diagnostics.CodeAnalysis;

namespace Student.Achieve.Domain.Aggregates.UserAggregate
{
    [SuppressMessage("Roslynator", "RCS1194:Implement exception constructors.", Justification = "<Pending>")]
    public class DuplicatedUserPhoneNumberException : DomainException
    {
        public const int ErrorCode = 1101;

        public DuplicatedUserPhoneNumberException(string message = "Phone number is already taken.") : base(message, ErrorCode)
        {
        }
    }
}