﻿using Fabricdot.WebApi.Endpoint;
using Fabricdot.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student.Achieve.Infrastructure.Security;
using Student.Achieve.WebApi.Application.Commands.Users;
using Student.Achieve.WebApi.Application.Queries.Users;
using Student.Achieve.WebApi.Authorization;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Endpoints
{
    /// <summary>
    ///     User
    /// </summary>
    [DefaultAuthorize]
    public class UserController : EndPointBase
    {
        /// <summary>
        ///     Create
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("create user")]
        [Authorize(ApplicationPermissions.Users.Create)]
        [HttpPost]
        public async Task<Guid> CreateAsync([FromBody] CreateUserCommand command)
        {
            return await CommandBus.PublishAsync(command);
        }

        /// <summary>
        ///     Update
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("update user")]
        [Authorize(ApplicationPermissions.Users.Update)]
        [HttpPut]
        public async Task UpdateAsync([FromBody] UpdateUserCommand command)
        {
            await CommandBus.PublishAsync(command);
        }

        /// <summary>
        ///     Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("delete user")]
        [Authorize(ApplicationPermissions.Users.Delete)]
        [HttpDelete("{id}")]
        public async Task DeleteAsync([FromRoute] Guid id)
        {
            await CommandBus.PublishAsync(new RemoveUserCommand(id));
        }

        /// <summary>
        ///     Change password of current user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Description("change password")]
        [HttpPost("current/password")]
        public async Task ChangePasswordAsync([FromBody] ChangePasswordDto request)
        {
            var userId = Guid.Parse(CurrentUser.Id!);
            await CommandBus.PublishAsync(new ChangePasswordCommand(userId, request));
        }

        /// <summary>
        ///     Enable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("enable user")]
        [Authorize(ApplicationPermissions.Users.Update)]
        [HttpPut("{id}/enable")]
        public async Task EnableAsync([FromRoute] Guid id)
        {
            await CommandBus.PublishAsync(new ChangeUserStatusCommand(id, true));
        }

        /// <summary>
        ///     Disable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("disable user")]
        [Authorize(ApplicationPermissions.Users.Update)]
        [HttpPut("{id}/disable")]
        public async Task DisableAsync([FromRoute] Guid id)
        {
            await CommandBus.PublishAsync(new ChangeUserStatusCommand(id, false));
        }

        /// <summary>
        ///     Lockout
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("lock user")]
        [Authorize(ApplicationPermissions.Users.Update)]
        [HttpPut("lockout")]
        public async Task LockoutAsync([FromBody] LockoutUserCommand command)
        {
            await CommandBus.PublishAsync(command);
        }

        /// <summary>
        ///     Unlock
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("unlock user")]
        [Authorize(ApplicationPermissions.Users.Update)]
        [HttpPut("unlock")]
        public async Task UnlockAsync([FromBody] UnlockUserCommand command)
        {
            await CommandBus.PublishAsync(command);
        }

        /// <summary>
        ///     Set default password
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("reset password")]
        [Authorize(ApplicationPermissions.Users.Update)]
        [HttpPut("password/default")]
        public async Task SetDefaultPasswordAsync([FromBody] SetDefaultPasswordCommand command)
        {
            await CommandBus.PublishAsync(command);
        }

        /// <summary>
        ///     Get details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("get user details")]
        [HttpGet("{id}")]
        [Authorize(ApplicationPermissions.Users.Read)]
        public async Task<UserDetailsDto> GetAsync([FromRoute] Guid id)
        {
            return await QueryProcessor.ProcessAsync(new GetUserDetailsQuery(id));
        }

        /// <summary>
        ///     Get detail of current user
        /// </summary>
        /// <returns></returns>
        [Description("get current user details")]
        [HttpGet("current")]
        public async Task<UserDetailsDto> GetCurrentAsync()
        {
            var userId = Guid.Parse(CurrentUser.Id!);
            var ret = await QueryProcessor.ProcessAsync(new GetUserDetailsQuery(userId));
            return ret!;
        }

        /// <summary>
        ///     Get paged list
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Description("get user paged list")]
        [HttpGet("paged-list")]
        [Authorize(ApplicationPermissions.Users.View)]
        public async Task<PagedResultDto<UserDetailsDto>> GetPagedListAsync([FromQuery] GetUserPagedListQuery query)
        {
            return await QueryProcessor.ProcessAsync(query);
        }
    }
}