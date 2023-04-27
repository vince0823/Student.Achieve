using Fabricdot.WebApi.Endpoint;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Achieve.WebApi.Application.Commands.Teachers;
using Student.Achieve.WebApi.Authorization;
using System.ComponentModel;
using System.Threading.Tasks;
using System;
using Student.Achieve.WebApi.Application.Commands.Grades;

namespace Student.Achieve.WebApi.Endpoints
{
    [DefaultAuthorize]
    public class GradeController : EndPointBase
    {
        /// <summary>
        /// 添加年级
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("添加年级")]
        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<Guid> CreateAsync([FromBody] CreateGradeCommand command)
        {
            return await CommandBus.PublishAsync(command);
        }

    }
}
