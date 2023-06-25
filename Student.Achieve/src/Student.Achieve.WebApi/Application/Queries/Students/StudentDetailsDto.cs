using AutoMapper;
using Student.Achieve.WebApi.Application.Queries.Classes;
using System;

namespace Student.Achieve.WebApi.Application.Queries.Students
{
    [AutoMap(typeof(Student.Achieve.Domain.Aggregates.StudentAggregate.Student))]
    public class StudentDetailsDto
    {
        public Guid Id { get; set; }
        public string StudentName { get; set; }
        public string PhoneNumber { get; set; }
        public string StudentEmail { get; set; }

        public string ClassName { get; set; }
        public ClassDto Class { get; set; }
    }
}
