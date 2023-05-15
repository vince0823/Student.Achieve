using Fabricdot.Infrastructure.Queries;
using Student.Achieve.WebApi.Application.Queries.Grades;
using System;

namespace Student.Achieve.WebApi.Application.Queries.Classes
{
    public class GetClassDetailsQuery : Query<ClassDetailsDto>
    {
        public Guid ClassId { get; set; }
        public GetClassDetailsQuery(Guid classId)
        {
            ClassId = classId;
        }
    }
}
