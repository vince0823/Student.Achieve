using Fabricdot.Infrastructure.Queries;
using Student.Achieve.WebApi.Application.Queries.Roles;
using System;

namespace Student.Achieve.WebApi.Application.Queries.Teachers
{
    public class GetTeacherDetailsQuery : Query<TeacherDetailsDto>
    {
        public Guid TeacherId { get; set; }
        public GetTeacherDetailsQuery(Guid teacherId)
        {
            TeacherId = teacherId;
        }
    }
}
