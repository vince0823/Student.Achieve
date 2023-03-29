using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Student.Achieve.Domain.Aggregates.RoleAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Roles
{
    internal class RemoveRoleCommandHandler : CommandHandler<RemoveRoleCommand>
    {
        private readonly RoleManager<Role> _roleManager;

        public RemoveRoleCommandHandler(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public override async Task<Unit> ExecuteAsync(
            RemoveRoleCommand command,
            CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(command.RoleId.ToString());
            Guard.Against.Null(role, nameof(role));
            await _roleManager.DeleteAsync(role);
            return Unit.Value;
        }
    }
}