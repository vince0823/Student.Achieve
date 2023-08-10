using Fabricdot.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.ExamTasks
{
    public class CreateExamTaskCommand : Command<Guid>
    {

        [Required(ErrorMessage = "请填写考试任务名称")]
        public string TaskName { get; set; }
        [Required(ErrorMessage = "请填写考试任务开始时间")]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "请填写考试任务结束时间")]
        public DateTime EndTime { get; set; }
        [Required(ErrorMessage = "请填写考试任务名称学年度")]
        public string AcademicYear { get; set; }
        public Semester Semester { get; set; }
        public List<Guid> CourseIds { get; set; }
        public List<Guid> ClassIds { get; set; }

    }
}
