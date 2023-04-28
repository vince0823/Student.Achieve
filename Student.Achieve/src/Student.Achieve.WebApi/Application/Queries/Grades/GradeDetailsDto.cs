using AutoMapper;
using Student.Achieve.Domain.Aggregates.GradeAggregate;
using Student.Achieve.Domain.Aggregates.TeacherAggregate;
using System;

namespace Student.Achieve.WebApi.Application.Queries.Grades
{
    [AutoMap(typeof(Grade))]
    public record GradeDetailsDto
    {
        public Guid Id { get; set; }
        public string GradeName { get; set; }
        public int EnrollmenYear { get; set; }
        public string DutyUserName { get; set; }
        public Guid DutyUserId { get; set; }
        public bool IsGraduated { get; set; }
    }
}
