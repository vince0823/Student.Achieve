using Fabricdot.Core.UniqueIdentifier;
using Fabricdot.Infrastructure.Commands;
using Fabricdot.MultiTenancy.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Student.Achieve.Domain.Aggregates.RoleAggregate;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Roles
{
    internal class CreateRoleCommandHandler : CommandHandler<CreateRoleCommand, Guid>
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IGuidGenerator _guidGenerator;
        private readonly ICurrentTenant _currentTenant;

        public CreateRoleCommandHandler(
            RoleManager<Role> roleManager,
            IGuidGenerator guidGenerator,
            ICurrentTenant currentTenant)
        {
            _roleManager = roleManager;
            _guidGenerator = guidGenerator;
            _currentTenant = currentTenant;
        }

        public override async Task<Guid> ExecuteAsync(
            CreateRoleCommand command,
            CancellationToken cancellationToken)
        {
            //var currentTenant = ServiceProvider.GetRequiredService<ICurrentTenant>();
            var role = new Role(_currentTenant.Id,_guidGenerator.Create(), command.Name)
            {
                Description = command.Description,
                IsDefault = command.IsDefault
            };
           
            await _roleManager.CreateAsync(role);
            return role.Id;
        }
    }
}