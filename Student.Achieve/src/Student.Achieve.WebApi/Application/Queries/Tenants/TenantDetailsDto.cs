using AutoMapper;
using Student.Achieve.Domain.Aggregates.TenantAggregate;

namespace Student.Achieve.WebApi.Application.Queries.Tenants
{
    [AutoMap(typeof(Tenant))]
    public class TenantDetailsDto : TenantDto
    {
        /// <summary>
        ///     所有人
        /// </summary>
        public TenantOwnerDto Owner { get; set; }
    }
}
