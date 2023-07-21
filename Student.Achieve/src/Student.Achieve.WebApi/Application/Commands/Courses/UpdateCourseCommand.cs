using Fabricdot.Infrastructure.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.Courses
{
    public class UpdateCourseCommand : Command<Guid>
    {
        public Guid CourseId { get; set; }
        [Required(ErrorMessage = "请填写课程名称")]
        public string CourseName { get; set; }
    }
}
