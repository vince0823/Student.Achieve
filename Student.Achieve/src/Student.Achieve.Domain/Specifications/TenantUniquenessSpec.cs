using Ardalis.GuardClauses;
using Ardalis.Specification;
using Fabricdot.MultiTenancy.Abstractions;
using Student.Achieve.Domain.Aggregates.TenantAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Specifications
{
    public sealed class TenantUniquenessSpec : Specification<Tenant>
    {
        public TenantUniquenessSpec(ITenant tenant)
        {
            Guard.Against.Null(tenant, nameof(tenant));
            Query.Where(v => v.NormalizedName == Tenant.NormalizeName(tenant.Name) && v.Id != tenant.Id);
        }
    }
}
