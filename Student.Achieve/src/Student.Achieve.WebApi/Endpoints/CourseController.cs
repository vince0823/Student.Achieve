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
using Microsoft.Extensions.DependencyInjection;
using Student.Achieve.WebApi.Services.ImportSheet;
using Student.Achieve.Infrastructure.Documents;
using System.IO;
using Student.Achieve.Domain.Repositories;
using NPOI.SS.Formula.Functions;
using System.Collections.Generic;

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

        /// <summary>
        ///     import to excel
        /// </summary>
        /// <param name="file"></param>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        [Description("导入课程")]
        //[AllowAnonymous]
        [HttpPost("{tenantId}/sheet")]
        public async Task<ImportSheetResultDto> ImportSheetAsync([FromForm] IFormFile file, Guid tenantId)
        {
            SpreadSheetValidator.EnsureExtensionIsValid(file.FileName);
            var excelService = ServiceProvider.GetRequiredService<IExcelService>();
            await using var stream = file.OpenReadStream();
            var rowValues = excelService.ReadValues(stream);

            return await CommandBus.PublishAsync(new ImportCoursesFromSheetCommand(rowValues, tenantId));
        }
        /// <summary>
        ///     export to excel
        /// </summary>
        /// <returns></returns>
        [Description("导出计划")]
        [AllowAnonymous]
        [HttpGet("export")]
        public async Task<IActionResult> ExportAsync()
        {
            var courseRepository = ServiceProvider.GetRequiredService<ICourseRepository>();
            var sources = await courseRepository.ListAsync();
            ICollection<Student.Achieve.Domain.Aggregates.CourseAggregate.Course> collection = new List<Student.Achieve.Domain.Aggregates.CourseAggregate.Course>(sources);
            var excelService = ServiceProvider.GetRequiredService<IExcelService>();
            string folder = Path.Combine(Directory.GetCurrentDirectory(), "Resources/Templates");
            string path = Path.Combine(folder, "course-form.xlsx");
            var fileStream = new FileStream(path, FileMode.Open);
            var lastStream = excelService.WriteCollection(fileStream, collection);

            //var fileStream=new FileStream(path, FileMode.Open);
            this.HttpContext.Response.Headers.Add("Content-Length", lastStream.Length.ToString());
            this.HttpContext.Response.Headers.Add("Content-Type", "charset=UTF-8");
            return File(lastStream, "application/octet-stream;charset=UTF-8", Path.GetFileName(path));
        }


    }
}
