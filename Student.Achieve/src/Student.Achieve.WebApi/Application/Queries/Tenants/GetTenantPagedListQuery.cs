using Fabricdot.Infrastructure.Queries;
using Fabricdot.WebApi.Models;

namespace Student.Achieve.WebApi.Application.Queries.Tenants
{
    public class GetTenantPagedListQuery : PageQueryBase<PagedResultDto<TenantDetailsDto>>
    {
        /// <summary>
        ///     租户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     管理员手机号
        /// </summary>
        public string OwnerPhoneNumber { get; set; }

        /// <summary>
        ///     是否启用
        /// </summary>
        public bool? IsEnabled { get; set; }
    }
}
