using AutoMapper;
using Student.Achieve.Domain.Aggregates.GradeAggregate;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Student.Achieve.WebApi.Application.Queries.Grades
{
    [AutoMap(typeof(Grade))]
    public class GradeTreeDto
    {
        public Guid Id { get; set; }
        public string GradeName { get; set; }
        public ICollection<ClassTreeDto> Dtos { get; set; }
    }
}
