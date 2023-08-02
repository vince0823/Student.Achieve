using AutoMapper;
using Student.Achieve.Domain.Aggregates.ClassAggregate;
using Student.Achieve.Domain.Aggregates.GradeAggregate;
using System;

namespace Student.Achieve.WebApi.Application.Queries.Grades
{

    [AutoMap(typeof(Class))]
    public class ClassTreeDto
    {
        public Guid Id { get; set; }
        public string ClassName { get; set; }
    }
}
