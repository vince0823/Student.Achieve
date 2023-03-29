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
    public class DuplicatedTenantException : DomainException
    {
        public const int ErrorCode = 1001;

        public DuplicatedTenantException(string message = "Tenant must be unique.") : base(message, ErrorCode)
        {
        }
    }
}
