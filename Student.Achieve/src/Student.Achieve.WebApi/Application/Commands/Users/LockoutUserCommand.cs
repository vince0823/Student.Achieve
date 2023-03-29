using Fabricdot.Infrastructure.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.Users
{
    public class LockoutUserCommand : Command
    {
        [Required]
        public Guid UserId { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }
    }
}