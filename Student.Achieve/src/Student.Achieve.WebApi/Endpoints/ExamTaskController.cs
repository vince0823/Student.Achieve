using Fabricdot.Infrastructure.Commands;
using Fabricdot.WebApi.Endpoint;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Achieve.WebApi.Application.Commands.Courses;
using Student.Achieve.WebApi.Application.Commands.ExamTasks;
using Student.Achieve.WebApi.Authorization;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Endpoints
{
    [DefaultAuthorize]
    public class ExamTaskController : EndPointBase
    {

        /// <summary>
        /// add  examtask
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("添加考试任务")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<Guid> CreateAsync([FromBody] CreateExamTaskCommand command)
        {
            return await CommandBus.PublishAsync(command);
        }
    }
}
