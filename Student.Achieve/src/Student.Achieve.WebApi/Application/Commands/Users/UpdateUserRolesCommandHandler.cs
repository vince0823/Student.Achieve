using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Users
{
    internal class UpdateUserRolesCommandHandler : CommandHandler<UpdateUserRolesCommand>
    {
        private readonly UserManager<User> _userManager;

        public UpdateUserRolesCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public override async Task<Unit> ExecuteAsync(
            UpdateUserRolesCommand command,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(command.UserId.ToString());
            Guard.Against.Null(user, nameof(user));

            user.ClearRoles();
            var res = await _userManager.AddToRolesAsync(user, command.RoleNames);
            res.EnsureSuccess();

            return Unit.Value;
        }
    }
}