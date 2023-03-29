using Fabricdot.Identity.Domain.Entities.RoleAggregate;
using System;

namespace Student.Achieve.Domain.Aggregates.RoleAggregate
{
    public class Role : IdentityRole
    {
        public bool IsStatic { get; private set; }

        public bool IsDefault { get; set; }

        public Role(
            Guid roleId,
            string roleName,
            bool isStatic = false) : base(roleId, roleName)
        {
            IsStatic = isStatic;
        }

        private Role()
        {
        }
    }
}