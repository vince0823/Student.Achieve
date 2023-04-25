using Fabricdot.Identity.Domain.Constants;
using Fabricdot.Infrastructure.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.Teachers
{
    public class CreateTeacherCommand : Command<Guid>
    {
        [Required]
        public string TeacherName { get; set; }
        [Required]
        public string TeacherEmail { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

    }
}
