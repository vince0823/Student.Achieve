using Fabricdot.WebApi.Endpoint;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Achieve.WebApi.Application.Commands.Grades;
using Student.Achieve.WebApi.Authorization;
using System.ComponentModel;
using System.Threading.Tasks;
using System;
using Fabricdot.WebApi.Models;
using Student.Achieve.WebApi.Application.Queries.Grades;
using System.Collections;
using System.Collections.Generic;

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
        /// <summary>
        ///     Update
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("update grade")]
        [AllowAnonymous]
        [HttpPut]
        public async Task UpdateAsync([FromBody] UpdateGradeCommand command)
        {
            await CommandBus.PublishAsync(command);
        }

        /// <summary>
        ///     Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("delete Grade")]
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task DeleteAsync([FromRoute] Guid id)
        {
            await CommandBus.PublishAsync(new RemoveGradeCommand(id));
        }

        /// <summary>
        ///     Get detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("get Grade details")]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<GradeDetailsDto> GetAsync([FromRoute] Guid id)
        {
            return await QueryProcessor.ProcessAsync(new GetGradeDetailsQuery(id));
        }

        /// <summary>
        ///     Get paged list
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Description("get Grade paged list")]
        [HttpGet("paged-list")]
        [AllowAnonymous]
        public async Task<PagedResultDto<GradeDetailsDto>> GetPagedListAsync([FromQuery] GetGradePagedListQuery query)
        {
            return await QueryProcessor.ProcessAsync(query);
        }
        /// <summary>
        /// Graduate
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("Graduate Grade")]
        [AllowAnonymous]
        [HttpPost("{id}")]
        public async Task GraduateAsync([FromRoute] Guid id)
        {
            await CommandBus.PublishAsync(new GraduateGradeCommand(id));
        }

        /// <summary>
        /// tree
        /// </summary>
        /// <returns></returns>
        [Description("get Grade and class tree")]
        [HttpGet("tree")]
        [AllowAnonymous]
        public async Task<ICollection<GradeTreeDto>> GetGradeTree([FromQuery] GetGradeTreeQuery query)
        {
            return await QueryProcessor.ProcessAsync(query);
        }

    }
}
