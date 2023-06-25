using Fabricdot.WebApi.Endpoint;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Achieve.WebApi.Application.Commands.Students;
using Student.Achieve.WebApi.Authorization;
using System.ComponentModel;
using System.Threading.Tasks;
using System;
using Fabricdot.WebApi.Models;
using Student.Achieve.WebApi.Application.Queries.Students;

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
        [Description("编辑学生")]
        [AllowAnonymous]
        [HttpPut]
        public async Task UpdateAsync([FromBody] UpdateStudentCommand command)
        {
            await CommandBus.PublishAsync(command);
        }

        /// <summary>
        ///     Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("delete Student")]
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task DeleteAsync([FromRoute] Guid id)
        {
            await CommandBus.PublishAsync(new RemoveStudentCommand(id));
        }

        /// <summary>
        ///     Get detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("get Student details")]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<StudentDetailsDto> GetAsync([FromRoute] Guid id)
        {
            return await QueryProcessor.ProcessAsync(new GetStudentDetailsQuery(id));
        }

        /// <summary>
        ///     Get paged list
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Description("get Student paged list")]
        [HttpGet("paged-list")]
        [AllowAnonymous]
        public async Task<PagedResultDto<StudentDetailsDto>> GetPagedListAsync([FromQuery] GetStudentPagedListQuery query)
        {
            return await QueryProcessor.ProcessAsync(query);
        }
    }
}
