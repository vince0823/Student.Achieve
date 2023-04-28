using Fabricdot.Infrastructure.Queries;
using System;

namespace Student.Achieve.WebApi.Application.Queries.Grades
{
    public class GetGradeDetailsQuery : Query<GradeDetailsDto>
    {
        public Guid GradeId { get; set; }
        public GetGradeDetailsQuery(Guid gradeId)
        {
            GradeId = gradeId;
        }
    }
}
