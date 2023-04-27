using Fabricdot.Infrastructure.Queries;
using Fabricdot.WebApi.Models;
using Student.Achieve.WebApi.Application.Queries.Roles;

namespace Student.Achieve.WebApi.Application.Queries.Teachers
{
    public class GetTeacherPagedListQuery : PageQueryBase<PagedResultDto<TeacherDetailsDto>>
    {
        public string TeacherName { get; set; }
        public string TeacherPhoneNumber { get; set; }
    }
}
