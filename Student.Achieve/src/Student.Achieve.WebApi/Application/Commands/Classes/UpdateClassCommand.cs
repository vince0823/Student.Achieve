﻿using Fabricdot.Infrastructure.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.Classes
{
    public class UpdateClassCommand : Command<Guid>
    {
        public Guid ClassId { get; set; }
        [Required(ErrorMessage = "请填写班级名称")]
        public string ClassName { get; set; }
        public Guid? DutyUserId { get; set; }
        public Guid GradeId { get; set; }

    }
}
