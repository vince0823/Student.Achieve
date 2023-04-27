using AutoMapper;
using Student.Achieve.Domain.Aggregates.RoleAggregate;
using Student.Achieve.Domain.Aggregates.TeacherAggregate;
using System;

namespace Student.Achieve.WebApi.Application.Queries.Teachers
{
    [AutoMap(typeof(Teacher))]
    public record TeacherDetailsDto
    {
        public Guid Id { get; set; }
        public string TeacherName { get; set; }
        public string TeacherEmail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
