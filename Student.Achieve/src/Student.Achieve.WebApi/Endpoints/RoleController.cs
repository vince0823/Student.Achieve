﻿using Fabricdot.WebApi.Endpoint;
using Fabricdot.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student.Achieve.Infrastructure.Security;
using Student.Achieve.WebApi.Application.Commands.Roles;
using Student.Achieve.WebApi.Application.Queries.Roles;
using Student.Achieve.WebApi.Authorization;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Endpoints
{
    [DefaultAuthorize]
    public class RoleController : EndPointBase
    {
        /// <summary>
        ///     Create
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("create role")]
        [Authorize(ApplicationPermissions.Roles.Create)]
        [HttpPost]
        public async Task<Guid> CreateAsync([FromBody] CreateRoleCommand command)
        {
            return await CommandBus.PublishAsync(command);
        }

        /// <summary>
        ///     Update
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("update role")]
        [Authorize(ApplicationPermissions.Roles.Update)]
        [HttpPut]
        public async Task UpdateAsync([FromBody] UpdateRoleCommand command)
        {
            await CommandBus.PublishAsync(command);
        }

        /// <summary>
        ///     Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("delete role")]
        [Authorize(ApplicationPermissions.Roles.Delete)]
        [HttpDelete("{id}")]
        public async Task DeleteAsync([FromRoute] Guid id)
        {
            await CommandBus.PublishAsync(new RemoveRoleCommand(id));
        }

        /// <summary>
        ///     Get detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("get role details")]
        [HttpGet("{id}")]
        [Authorize(ApplicationPermissions.Roles.Read)]
        public async Task<RoleDetailsDto> GetAsync([FromRoute] Guid id)
        {
            return await QueryProcessor.ProcessAsync(new GetRoleDetailsQuery(id));
        }

        /// <summary>
        ///     Get paged list
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Description("get role paged list")]
        [HttpGet("paged-list")]
        [Authorize(ApplicationPermissions.Roles.View)]
        public async Task<PagedResultDto<RoleDto>> GetPagedListAsync([FromQuery] GetRolePagedListQuery query)
        {
            return await QueryProcessor.ProcessAsync(query);
        }
    }
}