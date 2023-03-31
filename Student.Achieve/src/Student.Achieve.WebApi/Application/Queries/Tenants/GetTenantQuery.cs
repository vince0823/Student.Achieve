using Fabricdot.Infrastructure.Queries;
using System;

namespace Student.Achieve.WebApi.Application.Queries.Tenants
{
    /// <summary>
    ///     获取租户
    /// </summary>
    public class GetTenantQuery : Query<TenantDto>
    {
        public Guid TenantId { get; }

        public GetTenantQuery(Guid tenantId)
        {
            TenantId = tenantId;
        }
    }
}
