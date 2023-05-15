using Fabricdot.WebApi.Endpoint;
using Fabricdot.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Achieve.WebApi.Authorization;
using System.ComponentModel;
using System.Threading.Tasks;
using System;
using Student.Achieve.WebApi.Application.Commands.Classes;
using Student.Achieve.WebApi.Application.Queries.Classes;

namespace Student.Achieve.WebApi.Endpoints
{
    [DefaultAuthorize]
    public class ClassController : EndPointBase
    {

        /// <summary>
        /// 添加班级
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("添加班级")]
        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<Guid> CreateAsync([FromBody] CreateClassCommand command)
        {
            return await CommandBus.PublishAsync(command);
        }
        /// <summary>
        ///     Update
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("update Class")]
        [AllowAnonymous]
        [HttpPut]
        public async Task UpdateAsync([FromBody] UpdateClassCommand command)
        {
            await CommandBus.PublishAsync(command);
        }

        /// <summary>
        ///     Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("delete Class")]
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task DeleteAsync([FromRoute] Guid id)
        {
            await CommandBus.PublishAsync(new RemoveClassCommand(id));
        }

        /// <summary>
        ///     Get detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("get Class details")]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ClassDetailsDto> GetAsync([FromRoute] Guid id)
        {
            return await QueryProcessor.ProcessAsync(new GetClassDetailsQuery(id));
        }

        /// <summary>
        ///     Get paged list
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Description("get Class paged list")]
        [HttpGet("paged-list")]
        [AllowAnonymous]
        public async Task<PagedResultDto<ClassDetailsDto>> GetPagedListAsync([FromQuery] GetClassPagedListQuery query)
        {
            return await QueryProcessor.ProcessAsync(query);
        }
    }
}
