using AutoMapper;
using Fabricdot.Domain.Auditing;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.WebApi.Application.Queries.Roles;
using System;
using System.Collections.Generic;

namespace Student.Achieve.WebApi.Application.Queries.Users
{
    [AutoMap(typeof(User))]
    public class UserDetailsDto : IAuditEntity
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string GivenName { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool IsActive { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public bool LockoutEnabled { get; set; }

        public bool HasPassword { get; set; }

        public bool IsLockedOut { get; set; }

        /// <inheritdoc />
        public DateTime CreationTime { get; set; }

        /// <inheritdoc />
        public DateTime? LastModificationTime { get; set; }

        /// <inheritdoc />
        public string CreatorId { get; set; }

        /// <inheritdoc />
        public string LastModifierId { get; set; }

        public ICollection<RoleDto> Roles { get; set; } = new List<RoleDto>();
    }
}