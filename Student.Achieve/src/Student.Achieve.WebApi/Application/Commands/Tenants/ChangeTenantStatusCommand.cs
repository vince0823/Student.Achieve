using Fabricdot.Infrastructure.Commands;
using System;

namespace Student.Achieve.WebApi.Application.Commands.Tenants
{
    public class ChangeTenantStatusCommand:Command<Guid>
    {
        /// <summary>
        ///     租户Id
        /// </summary>
        public Guid TenantId { get; }

        /// <summary>
        ///     是否启用
        /// </summary>
        public bool IsEnabled { get; }

        public ChangeTenantStatusCommand(
            Guid tenantId,
            bool isEnabled)
        {
            TenantId = tenantId;
            IsEnabled = isEnabled;
        }
    }
}
