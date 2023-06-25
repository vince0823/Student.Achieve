using AutoMapper;
using Student.Achieve.Domain.Aggregates.ClassAggregate;
using Student.Achieve.Domain.Aggregates.GradeAggregate;
using Student.Achieve.WebApi.Application.Queries.Grades;
using System;

namespace Student.Achieve.WebApi.Application.Queries.Classes
{
    [AutoMap(typeof(Class))]
    public class ClassDetailsDto
    {
        public Guid Id { get; set; }
        public string ClassName { get; set; }
        public bool IsGraduated { get; set; }
        public string DutyUserName { get; set; }
        public Guid? DutyUserId { get; set; }
        public GradeDetailsDto Grade { get; set; }

    }
}
