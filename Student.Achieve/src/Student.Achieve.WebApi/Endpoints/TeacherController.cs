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
using Fabricdot.WebApi.Models;
using Student.Achieve.WebApi.Application.Queries.Teachers;

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


        /// <summary>
        ///     Update
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("update teacher")]
        [AllowAnonymous]
        [HttpPut]
        public async Task UpdateAsync([FromBody] UpdateTeacherCommand command)
        {
            await CommandBus.PublishAsync(command);
        }

        /// <summary>
        ///     Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("delete Teacher")]
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task DeleteAsync([FromRoute] Guid id)
        {
            await CommandBus.PublishAsync(new RemoveTeacherCommand(id));
        }

        /// <summary>
        ///     Get detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("get Teacher details")]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<TeacherDetailsDto> GetAsync([FromRoute] Guid id)
        {
            return await QueryProcessor.ProcessAsync(new GetTeacherDetailsQuery(id));
        }

        /// <summary>
        ///     Get paged list
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Description("get Teacher paged list")]
        [HttpGet("paged-list")]
        [AllowAnonymous]
        public async Task<PagedResultDto<TeacherDetailsDto>> GetPagedListAsync([FromQuery] GetTeacherPagedListQuery query)
        {
            return await QueryProcessor.ProcessAsync(query);
        }
    }
}
