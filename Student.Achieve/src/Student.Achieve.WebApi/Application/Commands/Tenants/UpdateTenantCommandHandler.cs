using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using MediatR;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Infrastructure.International.Converters;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Tenants
{
    public class UpdateTenantCommandHandler : CommandHandler<UpdateTenantCommand, Guid>
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IPinyinConverter _pinyinConverter;
        public UpdateTenantCommandHandler(ITenantRepository tenantRepository,
           IPinyinConverter pinyinConverter )
        {
            _tenantRepository = tenantRepository;
            _pinyinConverter= pinyinConverter;
        }

        public async override Task<Guid> ExecuteAsync(UpdateTenantCommand command, CancellationToken cancellationToken)
        {
            var tenant = await _tenantRepository.GetByIdAsync(command.TenantId, cancellationToken);
            Guard.Against.Null(tenant, nameof(tenant));
            var tenantName = _pinyinConverter.ToPinyin(command.Name);
            Guard.Against.Null(tenantName, nameof(tenantName));
            tenant.NormalizedName = tenantName;
            tenant.Name = command.Name;
            tenant.SetOwner(command.OwnerId);
            await _tenantRepository.UpdateAsync(tenant, cancellationToken);
            return tenant.Id;
        }
    }
}
