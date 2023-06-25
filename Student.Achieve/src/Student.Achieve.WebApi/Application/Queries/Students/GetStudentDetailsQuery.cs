using Fabricdot.Infrastructure.Queries;
using Student.Achieve.WebApi.Application.Queries.Classes;
using System;

namespace Student.Achieve.WebApi.Application.Queries.Students
{
    public class GetStudentDetailsQuery : Query<StudentDetailsDto>
    {
        public Guid StudentId { get; set; }
        public GetStudentDetailsQuery(Guid studentId)
        {
            StudentId = studentId;
        }
    }
}
