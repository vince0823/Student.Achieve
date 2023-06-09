﻿using Ardalis.GuardClauses;
using Fabricdot.Identity.Domain.Repositories;
using Fabricdot.Infrastructure.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Student.Achieve.Domain.Aggregates.RoleAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Roles
{
    internal class UpdateRoleCommandHandler : CommandHandler<UpdateRoleCommand>
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IRoleRepository<Role> _roleRepository;

        public UpdateRoleCommandHandler(
            RoleManager<Role> roleManager,
            IRoleRepository<Role> roleRepository)
        {
            _roleManager = roleManager;
            _roleRepository = roleRepository;
        }

        public override async Task<Unit> ExecuteAsync(
            UpdateRoleCommand command,
            CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetDetailsByIdAsync(command.RoleId);
            Guard.Against.Null(role, nameof(role));

            await _roleManager.SetRoleNameAsync(role, command.Name);
            role.Description = command.Description;
            role.IsDefault = role.IsDefault;
            await _roleManager.UpdateAsync(role);

            return Unit.Value;
        }
    }
}