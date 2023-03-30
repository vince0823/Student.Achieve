using Fabricdot.Domain.SharedKernel;
using Fabricdot.Identity.Domain.Entities.RoleAggregate;
using System;

namespace Student.Achieve.Domain.Aggregates.RoleAggregate
{
    public class Role : IdentityRole,IMultiTenant
    {
        public Guid? TenantId { get; private set; }
        public bool IsStatic { get; private set; }

        public bool IsDefault { get; set; }

        public Role(
            Guid roleId,
            string roleName,
            bool isStatic = false) : base(roleId, roleName)
        {
            IsStatic = isStatic;
        }
        public Role(
          Guid? tenantId,
          Guid roleId,
          string roleName) : base(roleId, roleName)
        {
            TenantId = tenantId;
        }
        private Role()
        {
        }
    }
}