using Fabricdot.Infrastructure.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.Users
{
    public class SetDefaultPasswordCommand : Command
    {
        [Required]
        public Guid UserId { get; set; }
    }
}