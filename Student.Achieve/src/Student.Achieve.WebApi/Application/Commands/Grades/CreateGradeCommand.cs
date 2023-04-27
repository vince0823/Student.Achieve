using Fabricdot.Infrastructure.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.Grades
{
    public class CreateGradeCommand : Command<Guid>
    {
        [Required(ErrorMessage ="请填写年级名称")]
        public string GradeName { get; set; }
        [Required(ErrorMessage = "请填写入学年份")]
        [Range(2000,9999, ErrorMessage="请填写合理的年份")]
        public int EnrollmenYear { get; set; }
        public Guid? DutyUserID { get; set; }   

    }
}
