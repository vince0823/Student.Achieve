using Fabricdot.Infrastructure.Queries;
using Fabricdot.WebApi.Models;
using Student.Achieve.WebApi.Application.Queries.Classes;

namespace Student.Achieve.WebApi.Application.Queries.Courses
{
    public class GetCoursePagedListQuery : PageQueryBase<PagedResultDto<CoursePageDto>>
    {
        public string CourseName { get; set; }

    }

}
