using Ardalis.GuardClauses;
using Fabricdot.Domain.Entities;
using Fabricdot.MultiTenancy.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Aggregates.TenantAggregate
{
    public class Tenant : FullAuditAggregateRoot<Guid>, ITenant
    {
        /// <summary>
        /// 租户名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///     租户名称
        /// </summary>
        public string NormalizedName { get; set; }
        /// <summary>
        /// 所属人ID
        /// </summary>
        public string OwnerId { get; private set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; private set; }
        private Tenant()
        {
        }
        internal Tenant(
           Guid tenantId,
           string tenantName,
           string ownerId)
        {
            Id = tenantId;
            SetName(tenantName);
            if (!string.IsNullOrEmpty(ownerId))
                SetOwner(ownerId);
            Enable();
        }
        public static string NormalizeName(string tenantName)
        {
            return tenantName?.Trim()?.ToUpperInvariant();
        }
        public void Enable() => IsEnabled = true;

        public void Disable() => IsEnabled = false;
        public void SetOwner(string ownerId)
        {
            OwnerId = Guard.Against.NullOrEmpty(ownerId, nameof(ownerId));
        }

        public void EnsureIsEnable()
        {
            if (!IsEnabled)
                throw new InvalidTenantStatusException();
        }

        internal void SetName(string tenantName)
        {
            NormalizedName = Guard.Against.NullOrEmpty(tenantName, nameof(tenantName));

        }
    }
}
