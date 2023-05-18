using Fabricdot.WebApi.Endpoint;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Achieve.WebApi.Application.Commands.Grades;
using Student.Achieve.WebApi.Authorization;
using System.ComponentModel;
using System.Threading.Tasks;
using System;
using Student.Achieve.WebApi.Application.Commands.Students;

namespace Student.Achieve.WebApi.Endpoints
{
    [DefaultAuthorize]
    public class SudentController : EndPointBase
    {

        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("添加学生")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<Guid> CreateAsync([FromBody] CreateStudentCommand command)
        {
            return await CommandBus.PublishAsync(command);
        }
    }
}
