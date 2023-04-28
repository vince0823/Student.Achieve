using Fabricdot.Infrastructure.Queries;
using Fabricdot.WebApi.Models;
using Student.Achieve.WebApi.Application.Queries.Teachers;

namespace Student.Achieve.WebApi.Application.Queries.Grades
{
    public class GetGradePagedListQuery : PageQueryBase<PagedResultDto<GradeDetailsDto>>
    {
        public string GradeName { get; set; }
        
    }
}
