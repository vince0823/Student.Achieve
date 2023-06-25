using Fabricdot.Infrastructure.Queries;
using Fabricdot.WebApi.Models;
using Student.Achieve.WebApi.Application.Queries.Classes;

namespace Student.Achieve.WebApi.Application.Queries.Students
{
    public class GetStudentPagedListQuery : PageQueryBase<PagedResultDto<StudentDetailsDto>>
    {
        public string StudentName { get; set; }

    }
}
