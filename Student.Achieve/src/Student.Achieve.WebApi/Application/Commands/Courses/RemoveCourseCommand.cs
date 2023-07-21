using Fabricdot.Infrastructure.Commands;
using System;

namespace Student.Achieve.WebApi.Application.Commands.Courses
{
    public class RemoveCourseCommand : Command<Guid>
    {
        public Guid CourseId { get; set; }
        public RemoveCourseCommand(Guid courseId)
        {
            CourseId = courseId;
        }
    }
}
