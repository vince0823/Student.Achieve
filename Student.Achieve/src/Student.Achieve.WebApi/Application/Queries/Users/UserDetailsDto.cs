using AutoMapper;
using Fabricdot.Domain.Auditing;
using Fabricdot.Domain.SharedKernel;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.WebApi.Application.Queries.Roles;
using System;
using System.Collections.Generic;

namespace Student.Achieve.WebApi.Application.Queries.Users
{
    
    public class UserDetailsDto : IAuditEntity, IMultiTenant
    {
        public Guid Id { get; set; }
        public Guid? TenantId { get; set; }

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