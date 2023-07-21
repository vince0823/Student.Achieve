using Fabricdot.WebApi.Endpoint;
using Fabricdot.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Threading.Tasks;
using System;
using Student.Achieve.WebApi.Authorization;
using Student.Achieve.WebApi.Application.Commands.Courses;
using Student.Achieve.WebApi.Application.Queries.Courses;

namespace Course.Achieve.WebApi.Endpoints
{
    [DefaultAuthorize]
    public class CourseController : EndPointBase
    {
        /// <summary>
        /// 添加课程
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("添加课程")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<Guid> CreateAsync([FromBody] CreateCourseCommand command)
        {
            return await CommandBus.PublishAsync(command);
        }
        /// <summary>
        /// edit course
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Description("编辑课程")]
        [AllowAnonymous]
        [HttpPut]
        public async Task UpdateAsync([FromBody] UpdateCourseCommand command)
        {
            await CommandBus.PublishAsync(command);
        }

        /// <summary>
        ///     Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("delete Course")]
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task DeleteAsync([FromRoute] Guid id)
        {
            await CommandBus.PublishAsync(new RemoveCourseCommand(id));
        }

        /// <summary>
        ///     Get detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("get Course details")]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<CourseDetailsDto> GetAsync([FromRoute] Guid id)
        {
            return await QueryProcessor.ProcessAsync(new GetCourseDetailsQuery(id));
        }

        /// <summary>
        ///     Get paged list
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Description("get Course paged list")]
        [HttpGet("paged-list")]
        [AllowAnonymous]
        public async Task<PagedResultDto<CoursePageDto>> GetPagedListAsync([FromQuery] GetCoursePagedListQuery query)
        {
            return await QueryProcessor.ProcessAsync(query);
        }

    }
}
