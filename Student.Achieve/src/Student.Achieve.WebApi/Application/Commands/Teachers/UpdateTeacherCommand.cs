using Fabricdot.Infrastructure.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.Teachers
{
    public class UpdateTeacherCommand : Command
    {
        [Required]
        public Guid TeacherId { get; set; }
        [Required]
        public string TeacherName { get; set; }
        [Required]
        public string TeacherEmail { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
