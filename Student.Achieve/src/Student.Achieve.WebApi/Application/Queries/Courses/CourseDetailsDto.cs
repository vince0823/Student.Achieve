using AutoMapper;
using Student.Achieve.Domain.Aggregates.ClassAggregate;
using System;

namespace Student.Achieve.WebApi.Application.Queries.Courses
{
    [AutoMap(typeof(Student.Achieve.Domain.Aggregates.CourseAggregate.Course))]
    public class CourseDetailsDto
    {
        public Guid Id { get; set; }
        public string CourseName { get; set; }
    }
}
