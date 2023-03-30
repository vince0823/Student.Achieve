using Fabricdot.Core.DependencyInjection;
using Fabricdot.MultiTenancy.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Aggregates.TenantAggregate
{
    [Dependency(ServiceLifetime.Transient)]
    public class TenantStore : TenantStoreBase
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantStore(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public override async Task<TenantContext> GetAsync(
            string identifier,
            CancellationToken cancellationToken = default)
        {
            var specification = new TenantIdentifierSpec(identifier);
            var tenant = await _tenantRepository.GetBySpecAsync(specification, cancellationToken);
            return tenant == null ? null : new TenantContext(tenant.Id, tenant.Name);
        }
    }
}
