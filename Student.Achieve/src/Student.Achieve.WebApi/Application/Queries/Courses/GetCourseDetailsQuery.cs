using Fabricdot.Infrastructure.Queries;
using Student.Achieve.WebApi.Application.Queries.Classes;
using System;

namespace Student.Achieve.WebApi.Application.Queries.Courses
{
    public class GetCourseDetailsQuery : Query<CourseDetailsDto>
    {
        public Guid CourseId { get; set; }
        public GetCourseDetailsQuery(Guid courseId)
        {
            CourseId = courseId;
        }
    }
}
