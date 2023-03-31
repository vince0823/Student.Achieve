using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using MediatR;
using Student.Achieve.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Tenants
{
    public class ChangeTenantStatusCommandHandler : CommandHandler<ChangeTenantStatusCommand, Guid>
    {
        private readonly ITenantRepository
            _tenantRepository;
        public ChangeTenantStatusCommandHandler(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }


        public async override Task<Guid> ExecuteAsync(ChangeTenantStatusCommand command, CancellationToken cancellationToken)
        {
            var tenant = await _tenantRepository.GetByIdAsync(command.TenantId, cancellationToken);
            Guard.Against.Null(tenant, nameof(tenant));
            if (command.IsEnabled)
                tenant.Enable();
            else
                tenant.Disable();
            await _tenantRepository.UpdateAsync(tenant, cancellationToken);
            return tenant.Id;
        }
    }
}
