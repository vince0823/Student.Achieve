using Fabricdot.WebApi.Endpoint;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Achieve.WebApi.Authorization;
using System.ComponentModel;
using System.Threading.Tasks;
using System;
using Student.Achieve.WebApi.Application.Commands.Tenants;

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

    }
}
