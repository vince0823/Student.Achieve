using AutoMapper;
using Student.Achieve.Domain.Aggregates.ClassAggregate;
using System;

namespace Student.Achieve.WebApi.Application.Queries.Classes
{
    [AutoMap(typeof(Class))]
    public class ClassDto
    {
        public Guid Id { get; set; }
        public string ClassName { get;  set; }
    }
}
