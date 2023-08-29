using AutoMapper;
using Student.Achieve.Domain.Aggregates.ExamTaskAggregate;
using System.Collections.Generic;
using System;

namespace Student.Achieve.WebApi.Application.Queries.ExamTasks
{
    [AutoMap(typeof(ExamTask))]
    public class ExamTaskPageDto
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string AcademicYear { get; set; }
        public Semester Semester { get; set; }
        public string CourseNames { get; set; }
        public string ClassNames { get; set; }
    }
}
