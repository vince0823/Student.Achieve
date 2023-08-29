using Fabricdot.Infrastructure.Commands;
using Fabricdot.WebApi.Endpoint;
using Fabricdot.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Achieve.WebApi.Application.Commands.ExamTasks;
using Student.Achieve.WebApi.Application.Queries.ExamTasks;
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
        /// <summary>
        /// edit examtask
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("编辑考试任务")]
        [AllowAnonymous]
        [HttpPut]
        public async Task UpdateAsync([FromBody] UpdateExamTaskCommand command)
        {
            await CommandBus.PublishAsync(command);
        }
        /// <summary>
        ///     Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("delete ExamTask")]
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task DeleteAsync([FromRoute] Guid id)
        {
            await CommandBus.PublishAsync(new RemoveExamTaskCommand(id));
        }

        /// <summary>
        ///     Get detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("get ExamTask details")]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ExamTaskDetailsDto> GetAsync([FromRoute] Guid id)
        {
            return await QueryProcessor.ProcessAsync(new GetExamTaskDetailsQuery(id));
        }

        /// <summary>
        ///     Get paged list
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Description("get ExamTask paged list")]
        [HttpGet("paged-list")]
        [AllowAnonymous]
        public async Task<PagedResultDto<ExamTaskPageDto>> GetPagedListAsync([FromQuery] GetExamTaskPagedListQuery query)
        {
            return await QueryProcessor.ProcessAsync(query);
        }


    }
}
