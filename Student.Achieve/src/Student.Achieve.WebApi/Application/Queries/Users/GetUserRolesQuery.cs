using Student.Achieve.WebApi.Application.Queries.Roles;
using System;
using System.Collections.Generic;

namespace Student.Achieve.WebApi.Application.Queries.Users
{
    public class GetUserRolesQuery : UserQueryBase<ICollection<RoleDto>>
    {
        public GetUserRolesQuery(Guid userId) : base(userId)
        {
        }
    }
}