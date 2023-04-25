using Fabricdot.WebApi.Endpoint;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Achieve.WebApi.Application.Commands.Tenants;
using Student.Achieve.WebApi.Authorization;
using System.ComponentModel;
using System.Threading.Tasks;
using System;
using Student.Achieve.WebApi.Application.Commands.Teachers;

namespace Student.Achieve.WebApi.Endpoints
{
    [DefaultAuthorize]
    public class TeacherController : EndPointBase
    {

        /// <summary>
        /// 添加教师
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("添加教师")]
        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<Guid> CreateAsync([FromBody] CreateTeacherCommand command)
        {
            return await CommandBus.PublishAsync(command);
        }
    }
}
