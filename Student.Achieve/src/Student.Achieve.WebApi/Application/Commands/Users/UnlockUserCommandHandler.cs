using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Users
{
    internal class UnlockUserCommandHandler : CommandHandler<UnlockUserCommand>
    {
        private readonly UserManager<User> _userManager;

        public UnlockUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public override async Task<Unit> ExecuteAsync(
            UnlockUserCommand command,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(command.UserId.ToString());
            Guard.Against.Null(user, nameof(user));

            if (user.IsLockedOut)
            {
                var res = await _userManager.SetLockoutEnabledAsync(user, true);
                res.EnsureSuccess();
                res = await _userManager.SetLockoutEndDateAsync(user, null);
                res.EnsureSuccess();
            }
            return Unit.Value;
        }
    }
}