using Ardalis.Specification;
using Student.Achieve.Domain.Aggregates.TenantAggregate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Specifications
{
    public sealed class TenantIdentifierSpec : Specification<Tenant>
    {
        public TenantIdentifierSpec(string identifier)
        {
            if (Guid.TryParse(identifier, out var id))
                Query.Where(v => v.Id == id);
            else
                Query.Where(v => v.NormalizedName == Tenant.NormalizeName(identifier));
        }
    }
}
