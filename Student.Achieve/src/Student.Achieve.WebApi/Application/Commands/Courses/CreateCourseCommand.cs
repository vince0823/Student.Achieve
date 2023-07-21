using Fabricdot.Infrastructure.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.Courses
{
    public class CreateCourseCommand : Command<Guid>
    {
        [Required(ErrorMessage = "请填写课程名称")]
        public string CourseName { get; set; }

    }
}
