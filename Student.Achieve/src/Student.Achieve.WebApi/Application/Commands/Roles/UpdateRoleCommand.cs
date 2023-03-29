using Fabricdot.Identity.Domain.Constants;
using Fabricdot.Infrastructure.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.Roles
{
    public class UpdateRoleCommand : Command
    {
        [Required]
        public Guid RoleId { get; set; }

        [Required]
        [MaxLength(IdentityRoleConstant.NameLength)]
        public string Name { get; set; }

        [MaxLength(IdentityRoleConstant.DescriptionLength)]
        public string Description { get; set; }

        public bool IsDefault { get; set; }
    }
}