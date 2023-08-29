using Fabricdot.Infrastructure.Queries;
using Fabricdot.WebApi.Models;
using Student.Achieve.WebApi.Application.Queries.Courses;

namespace Student.Achieve.WebApi.Application.Queries.ExamTasks
{
    public class GetExamTaskPagedListQuery : PageQueryBase<PagedResultDto<ExamTaskPageDto>>
    {
        public string TaskName { get; set; }
        public string AcademicYear { get; set; }
        /// <summary>
        /// 1 上学期  2 下学期
        /// </summary>
        public int? Semester { get; set; }
    }
}
