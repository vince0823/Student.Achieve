using Fabricdot.WebApi.Endpoint;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student.Achieve.Infrastructure.Security;
using Student.Achieve.WebApi.Application.Queries.Permissions;
using Student.Achieve.WebApi.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Endpoints.Permissions
{
    /// <summary>
    ///     User permission
    /// </summary>
    [DefaultAuthorize]
    [Route("api/user")]
    public class UserPermissionController : EndPointBase
    {
        /// <summary>
        ///     List all permissions of user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("list all granted permissions of user")]
        [Authorize(ApplicationPermissions.Users.Read)]
        [HttpGet("{id}/permissions")]
        public async Task<ICollection<string>> ListAsync([FromRoute] Guid id)
        {
            return await QueryProcessor.ProcessAsync(new GetUserPermissionsQuery(id));
        }

        /// <summary>
        ///     List all permissions of current user
        /// </summary>
        /// <returns></returns>
        [Description("list all granted permissions of current user")]
        [HttpGet("current/permissions")]
        public async Task<ICollection<string>> ListCurrentAsync()
        {
            var userId = Guid.Parse(CurrentUser.Id!);
            return await QueryProcessor.ProcessAsync(new GetUserPermissionsQuery(userId));
        }
    }
}