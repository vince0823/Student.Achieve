﻿using Fabricdot.Identity.Domain.Constants;
using Fabricdot.Infrastructure.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.Roles
{
    public class CreateRoleCommand : Command<Guid>
    {
        [Required]
        [MaxLength(IdentityRoleConstant.NameLength)]
        public string Name { get; set; }

        [MaxLength(IdentityRoleConstant.DescriptionLength)]
        public string Description { get; set; }

        public bool IsDefault { get; set; }
    }
}