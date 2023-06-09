﻿using Fabricdot.Identity.Domain.Constants;
using Fabricdot.Infrastructure.Commands;
using Student.Achieve.Domain.Shared.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.Users
{
    public class CreateUserCommand : Command<Guid>
    {
        [Required]
        [MaxLength(IdentityUserConstant.UserNameLength)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(UserConstants.PasswordLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MaxLength(IdentityUserConstant.GivenNameLength)]
        public string GivenName { get; set; }

        [MaxLength(IdentityUserConstant.SurnameLength)]
        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(1)]
        public Guid[] OrganizationIds { get; set; } = Array.Empty<Guid>();
    }
}