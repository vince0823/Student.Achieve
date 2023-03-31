using Fabricdot.Infrastructure.Commands;
using System;

namespace Student.Achieve.WebApi.Application.Commands.Tenants
{
    public class ChangeTenantOwnerCommand : Command<Guid>
    {
        /// <summary>
        ///     租户Id
        /// </summary>
        public Guid TenantId { get; set; }
        /// <summary>
        ///     用户Id
        /// </summary>
        public Guid OwnerId { get; set; }
    }
}
