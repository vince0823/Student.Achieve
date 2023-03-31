using AutoMapper;
using Student.Achieve.Domain.Aggregates.TenantAggregate;
using System;

namespace Student.Achieve.WebApi.Application.Queries.Tenants
{
    [AutoMap(typeof(Tenant))]
    public class TenantDto
    {
        /// <summary>
        ///     Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        ///     所有人Id
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        ///     创建人Id
        /// </summary>
        public string CreatorId { get; set; }

        /// <summary>
        ///     修改时间
        /// </summary>
        public DateTime LastModificationTime { get; set; }

        /// <summary>
        ///     修改人Id
        /// </summary>
        public string LastModifierId { get; set; }
    }
}
