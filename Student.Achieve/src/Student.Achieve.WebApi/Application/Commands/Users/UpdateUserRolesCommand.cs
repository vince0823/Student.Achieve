using Fabricdot.Infrastructure.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.Users
{
    public class UpdateUserRolesCommand : Command
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string[] RoleNames { get; set; } = Array.Empty<string>();
    }
}