using AutoMapper;
using Student.Achieve.Domain.Aggregates.RoleAggregate;
using Student.Achieve.WebApi.Application.Models.ReadModels;
using System;
using System.Collections.Generic;

namespace Student.Achieve.WebApi.Application.Queries.Roles
{
    [AutoMap(typeof(Role))]
    public class RoleDetailsDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsStatic { get; set; }

        public bool IsDefault { get; set; }

        public ICollection<ClaimDto> Claims { get; set; } = new List<ClaimDto>();
    }
}