using Fabricdot.Core.UniqueIdentifier;
using Fabricdot.Domain.Services;
using Fabricdot.MultiTenancy.Abstractions;
using Student.Achieve.Domain.Events;
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
    public class TenantService : ITenantService
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly ITenantRepository _tenantRepository;

        public TenantService(
            IGuidGenerator guidGenerator,
            ITenantRepository tenantRepository)
        {
            _guidGenerator = guidGenerator;
            _tenantRepository = tenantRepository;
        }

        /// <inheritdoc />
        public async Task<Tenant> CreateAsync(
            string tenantName,
            string ownerId,
            CancellationToken cancellationToken = default)
        {
            var tenant = new Tenant(
                _guidGenerator.Create(),
                tenantName,
                ownerId);
            await EnsureIsUniqueAsync(tenant, cancellationToken);
            return tenant;
        }

        /// <inheritdoc />
        public async Task<Tenant> CreateAsync(
            string tenantName,
            TenantOwnerInfo owner,
            CancellationToken cancellationToken = default)
        {
            if (owner != null && owner.UserId == default)
                owner.UserId = _guidGenerator.Create();
            var tenant = await CreateAsync(
                tenantName,
                owner?.UserId.ToString(),
                cancellationToken);
            tenant.AddDomainEvent(new TenantCreatedEvent(tenant.Id, owner));

            return tenant;
        }

        /// <inheritdoc />
        public async Task EnsureIsUniqueAsync(
            ITenant tenant,
            CancellationToken cancellationToken = default)
        {
            var specification = new TenantUniquenessSpec(tenant);
            var isExisted = await _tenantRepository.AnyAsync(specification, cancellationToken: cancellationToken);
            if (isExisted)
                throw new DuplicatedTenantException();
        }

       
    }
}
