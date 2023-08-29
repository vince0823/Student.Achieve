using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using AutoMapper;
using Student.Achieve.Domain.Aggregates.ExamTaskAggregate;

namespace Student.Achieve.WebApi.Application.Queries.ExamTasks
{
    [AutoMap(typeof(ExamTask))]
    public class ExamTaskDetailsDto
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string AcademicYear { get; set; }
        public Semester Semester { get; set; }
        public List<Guid> CourseIds { get; set; }
        public List<Guid> ClassIds { get; set; }

    }
}
