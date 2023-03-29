using Fabricdot.Authorization;
using Fabricdot.Infrastructure.Commands;
using Fabricdot.PermissionGranting;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Permissions
{
    internal class UpdateGrantedPermissionsCommandHandler : CommandHandler<UpdateGrantedPermissionsCommand>
    {
        private readonly IPermissionGrantingManager _permissionGrantingManager;

        public UpdateGrantedPermissionsCommandHandler(IPermissionGrantingManager permissionGrantingManager)
        {
            _permissionGrantingManager = permissionGrantingManager;
        }

        public override async Task<Unit> ExecuteAsync(
            UpdateGrantedPermissionsCommand command,
            CancellationToken cancellationToken)
        {
            await _permissionGrantingManager.SetAsync(
                new GrantSubject(command.GrantType, command.Subject),
                command.Objects,
                cancellationToken);

            return Unit.Value;
        }
    }
}