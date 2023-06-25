using Fabricdot.Infrastructure.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.Students
{
    public class UpdateStudentCommand : Command
    {
        [Required]
        public Guid StudentId { get; set; }
        [Required(ErrorMessage = "请填写学生联系电话")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "请填写学生联系邮箱")]
        public string StudentEmail { get; set; }
        [Required(ErrorMessage = "请填写学生姓名")]
        public string StudentName { get; private set; }
        /// <summary>
        /// 班级Id
        /// </summary>
        public Guid ClassId { get; set; }
    }
}
