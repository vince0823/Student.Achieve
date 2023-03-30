using Fabricdot.Infrastructure.Commands;
using MediatR;
using Student.Achieve.Domain.Aggregates.TenantAggregate;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Infrastructure.International.Converters;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Tenants
{
    public class RegisterTenantCommandHandler : CommandHandler<RegisterTenantCommand, Guid>
    {
        private readonly ITenantService _tenantService;
        private readonly IPinyinConverter _pinyinConverter;
        private readonly ITenantRepository _tenantRepository;

        public RegisterTenantCommandHandler(
            ITenantService tenantService,
            IPinyinConverter pinyinConverter,
            ITenantRepository tenantRepository)
        {
            _tenantService = tenantService;
            _pinyinConverter = pinyinConverter;
            _tenantRepository = tenantRepository;
        }

        public async override Task<Guid> ExecuteAsync(RegisterTenantCommand command, CancellationToken cancellationToken)
        {
            var tenantName = _pinyinConverter.ToPinyin(command.Name);
               
            var tenant = await _tenantService.CreateAsync(
                tenantName,
                new TenantOwnerInfo
                {
                    UserId = default,
                    UserName = command.UserName,
                    Password = command.Password,
                    GivenName = command.GivenName,
                    Surname = command.Surname,
                    PhoneNumber = command.PhoneNumber,
                });
            tenant.Name= command.Name;
            await _tenantRepository.AddAsync(tenant, cancellationToken);

            return tenant.Id;
        }




    }
}
