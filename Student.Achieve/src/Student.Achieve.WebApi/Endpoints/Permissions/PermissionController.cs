using Fabricdot.Authorization.Permissions;
using Fabricdot.WebApi.Endpoint;
using Microsoft.AspNetCore.Mvc;
using Student.Achieve.WebApi.Application.Queries.Permissions;
using Student.Achieve.WebApi.Authorization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Endpoints.Permissions
{
    /// <summary>
    ///     Permission
    /// </summary>
    [DefaultAuthorize]
    public class PermissionController : EndPointBase
    {
        /// <summary>
        ///     list
        /// </summary>
        /// <returns></returns>
        [Description("list permission")]
        [HttpGet("list")]
        public async Task<ICollection<PermissionGroup>> ListAsync()
        {
            return await QueryProcessor.ProcessAsync(new GetPermissionGroupsQuery());
        }
    }
}