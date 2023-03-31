using Ardalis.GuardClauses;
using Fabricdot.Identity.Domain.Repositories;
using Fabricdot.Infrastructure.Commands;
using Fabricdot.MultiTenancy.Abstractions;
using MediatR;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Tenants
{
    public class ChangeTenantOwnerCommandHandler : CommandHandler<ChangeTenantOwnerCommand, Guid>
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly ICurrentTenant _currentTenant;
        public ChangeTenantOwnerCommandHandler(
          ITenantRepository tenantRepository,
          IUserRepository<User> userRepository,
          ICurrentTenant currentTenant)
        {
            _tenantRepository = tenantRepository;
            _userRepository = userRepository;
            _currentTenant = currentTenant;
        }
        public async override Task<Guid> ExecuteAsync(ChangeTenantOwnerCommand command, CancellationToken cancellationToken)
        {
            var tenant = await _tenantRepository.GetByIdAsync(command.TenantId, cancellationToken);
            Guard.Against.Null(tenant, nameof(tenant));

            using var scope = _currentTenant.Change(command.TenantId);
            var owner = await _userRepository.GetByIdAsync(command.OwnerId);
            Guard.Against.Null(owner, nameof(owner));

            tenant.SetOwner(command.OwnerId.ToString());
            await _tenantRepository.UpdateAsync(tenant, cancellationToken);

            return tenant.Id;
        }
    }
}
