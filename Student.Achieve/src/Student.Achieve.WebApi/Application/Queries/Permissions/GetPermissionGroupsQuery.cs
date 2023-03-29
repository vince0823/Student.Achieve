using Fabricdot.Authorization.Permissions;
using Fabricdot.Infrastructure.Queries;
using System.Collections.Generic;

namespace Student.Achieve.WebApi.Application.Queries.Permissions
{
    /// <summary>
    ///     List groups of permission
    /// </summary>
    public class GetPermissionGroupsQuery : Query<ICollection<PermissionGroup>>
    {
    }
}