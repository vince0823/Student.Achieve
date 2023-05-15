using Fabricdot.Infrastructure.Queries;
using Fabricdot.WebApi.Models;
using Student.Achieve.WebApi.Application.Queries.Grades;

namespace Student.Achieve.WebApi.Application.Queries.Classes
{
    public class GetClassPagedListQuery : PageQueryBase<PagedResultDto<ClassDetailsDto>>
    {
        public string ClassName { get; set; }

    }
}
