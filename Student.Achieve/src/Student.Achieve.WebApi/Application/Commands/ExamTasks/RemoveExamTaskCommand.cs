using Fabricdot.Infrastructure.Commands;
using System;

namespace Student.Achieve.WebApi.Application.Commands.ExamTasks
{
    public class RemoveExamTaskCommand : Command<Guid>
    {
        public Guid ExamTaskId { get; set; }
        public RemoveExamTaskCommand(Guid examTaskId)
        {
            ExamTaskId = examTaskId;
        }
    }
}
