using Fabricdot.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Aggregates.TenantAggregate
{
    [SuppressMessage("Roslynator", "RCS1194:Implement exception constructors.", Justification = "<Pending>")]
    public class InvalidTenantStatusException : DomainException
    {
        public const int ErrorCode = 1002;

        public InvalidTenantStatusException(string message = "Tenant is disabled.") : base(message, ErrorCode)
        {
        }
    }
}
