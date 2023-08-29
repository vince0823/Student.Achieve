using Fabricdot.Infrastructure.Queries;
using Student.Achieve.WebApi.Application.Queries.Courses;
using System;

namespace Student.Achieve.WebApi.Application.Queries.ExamTasks
{
    public class GetExamTaskDetailsQuery : Query<ExamTaskDetailsDto>
    {
        public Guid ExamTaskId { get; set; }
        public GetExamTaskDetailsQuery(Guid examTaskId)
        {
            ExamTaskId = examTaskId;
        }
    }
}
