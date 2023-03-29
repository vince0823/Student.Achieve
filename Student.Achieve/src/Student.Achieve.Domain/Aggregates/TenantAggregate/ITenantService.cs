using Fabricdot.Domain.Services;
using Fabricdot.MultiTenancy.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Aggregates.TenantAggregate
{
    /// <summary>
    ///     租户服务
    /// </summary>
    public interface ITenantService : IDomainService
    {
        /// <summary>
        ///     创建
        /// </summary>
        /// <param name="tenantName"></param>
        /// <param name="ownerId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Tenant> CreateAsync(
            string tenantName,
            string ownerId,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     创建
        /// </summary>
        /// <param name="tenantName"></param>
        /// <param name="owner"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Tenant> CreateAsync(
            string tenantName,
            TenantOwnerInfo owner,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     确保唯一性
        /// </summary>
        /// <param name="tenant"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task EnsureIsUniqueAsync(
            ITenant tenant,
            CancellationToken cancellationToken = default);
    }
}
