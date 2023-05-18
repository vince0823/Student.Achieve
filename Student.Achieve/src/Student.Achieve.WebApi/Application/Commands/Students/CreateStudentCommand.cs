using Fabricdot.Infrastructure.Commands;
using System.ComponentModel.DataAnnotations;
using System;

namespace Student.Achieve.WebApi.Application.Commands.Students
{
    public class CreateStudentCommand : Command<Guid>
    {
        [Required(ErrorMessage = "请填写学生名称")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "请填写学生联系电话")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "请填写学生联系邮箱")]
        public string StudentEmail { get; set; }
        /// <summary>
        /// 班级Id
        /// </summary>
        public Guid ClassId { get; set; }

    }
}
