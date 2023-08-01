using Student.Achieve.Domain.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.Courses
{
    public class ImporCourseDto
    {
        /// <summary>
     ///     工程编号
     /// </summary>
        [Required(ErrorMessage = ValidationMessage.FieldIsRequired)]
        [MaxLength(CourseConstants.ProjectCodeLength, ErrorMessage = ValidationMessage.FieldHasNaximumLength)]
        [Display(Name = "课程名称")]
        public string CourseName { get; set; }
    }
}
