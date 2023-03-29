using Fabricdot.Authorization.Permissions;
using Fabricdot.Infrastructure.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Queries.Permissions
{
    internal class GetPermissionGroupsQueryHandler : QueryHandler<GetPermissionGroupsQuery, ICollection<PermissionGroup>>
    {
        private readonly IPermissionManager _permissionManager;

        public GetPermissionGroupsQueryHandler(IPermissionManager permissionManager)
        {
            _permissionManager = permissionManager;
        }

        public override async Task<ICollection<PermissionGroup>> ExecuteAsync(
            GetPermissionGroupsQuery query,
            CancellationToken cancellationToken)
        {
            var groups = await _permissionManager.ListGroupsAsync();
            return groups.ToList();
        }
    }
}