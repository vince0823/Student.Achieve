using AutoMapper;
using System;

namespace Student.Achieve.WebApi.Application.Queries.Courses
{
    [AutoMap(typeof(Student.Achieve.Domain.Aggregates.CourseAggregate.Course))]
    public class CoursePageDto
    {
        public Guid Id { get; set; }
        public string CreatorId { get; set; }
        //public string ClassName { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
