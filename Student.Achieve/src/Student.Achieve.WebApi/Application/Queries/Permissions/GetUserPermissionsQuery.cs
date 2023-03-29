using Fabricdot.Infrastructure.Queries;
using System;
using System.Collections.Generic;

namespace Student.Achieve.WebApi.Application.Queries.Permissions
{
    /// <summary>
    ///     List all permissions of user
    /// </summary>
    public class GetUserPermissionsQuery : Query<ICollection<string>>
    {
        public Guid UserId { get; }

        public GetUserPermissionsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}