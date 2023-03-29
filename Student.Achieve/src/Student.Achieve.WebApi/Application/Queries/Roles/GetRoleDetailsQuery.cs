using Fabricdot.Infrastructure.Queries;
using System;

namespace Student.Achieve.WebApi.Application.Queries.Roles
{
    public class GetRoleDetailsQuery : Query<RoleDetailsDto>
    {
        public Guid RoleId { get; }

        public GetRoleDetailsQuery(Guid roleId)
        {
            RoleId = roleId;
        }
    }
}