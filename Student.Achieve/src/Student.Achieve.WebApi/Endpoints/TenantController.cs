using Fabricdot.WebApi.Endpoint;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Achieve.WebApi.Authorization;
using System.ComponentModel;
using System.Threading.Tasks;
using System;
using Student.Achieve.WebApi.Application.Commands.Tenants;
using Student.Achieve.Infrastructure.Security;
using Fabricdot.MultiTenancy.Abstractions;
using Fabricdot.WebApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Student.Achieve.WebApi.Application.Queries.Tenants;

namespace Student.Achieve.WebApi.Endpoints
{
    /// <summary>
    ///     租户
    /// </summary>
    [DefaultAuthorize]
    public class TenantController : EndPointBase
    {
        /// <summary>
        ///     注册
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("注册租户")]
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<Guid> RegisterAsync([FromBody] RegisterTenantCommand command)
        {
            return await CommandBus.PublishAsync(command);
        }

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("更新租户")]
        [Authorize(ApplicationPermissions.Tenants.Update)]
        [HttpPut]
        public async Task UpdateAsync([FromBody] UpdateTenantCommand command)
        {
            await CommandBus.PublishAsync(command);
        }

        /// <summary>
        ///     更换管理员
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("更换租户管理员")]
        [Authorize(ApplicationPermissions.Tenants.Update)]
        [HttpPost("{id}/owner")]
        public async Task ChangeOwnerAsync([FromBody] ChangeTenantOwnerCommand command)
        {
            await CommandBus.PublishAsync(command);
        }

        /// <summary>
        ///     启用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("启用租户")]
        [Authorize(ApplicationPermissions.Tenants.Update)]
        [HttpPut("{id}/enable")]
        public async Task EnableAsync([FromRoute] Guid id)
        {
            await CommandBus.PublishAsync(new ChangeTenantStatusCommand(id, true));
        }

        /// <summary>
        ///     禁用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("禁用租户")]
        [Authorize(ApplicationPermissions.Tenants.Update)]
        [HttpPut("{id}/disable")]
        public async Task DisableAsync([FromRoute] Guid id)
        {
            await CommandBus.PublishAsync(new ChangeTenantStatusCommand(id, false));
        }

        /// <summary>
        ///     获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(ApplicationPermissions.Tenants.Read)]
        [HttpGet("{id}")]
        public async Task<TenantDto> GetAsync([FromRoute] Guid id)
        {
            return await QueryProcessor.ProcessAsync(new GetTenantQuery(id));
        }

        /// <summary>
        ///     当前租户
        /// </summary>
        /// <returns></returns>
        [HttpGet("current")]
        public async Task<TenantDto> GetCurrentAsync()
        {
            var currentTenant = ServiceProvider.GetRequiredService<ICurrentTenant>();
            var tenantId = currentTenant.Id;
            return tenantId.HasValue ? await QueryProcessor.ProcessAsync(new GetTenantQuery(tenantId.Value)) : null;
        }

        /// <summary>
        ///     分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Authorize(ApplicationPermissions.Tenants.View)]
        [HttpGet("paged-list")]
        public async Task<PagedResultDto<TenantDetailsDto>> GetPagedListAsync([FromQuery] GetTenantPagedListQuery query)
        {
            return await QueryProcessor.ProcessAsync(query);
        }
    }
}
