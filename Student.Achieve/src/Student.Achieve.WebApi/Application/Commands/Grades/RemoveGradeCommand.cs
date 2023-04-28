using Fabricdot.Infrastructure.Commands;
using System;

namespace Student.Achieve.WebApi.Application.Commands.Grades
{
    public class RemoveGradeCommand : Command<Guid>
    {
        public Guid GradeId { get; set; }
        public RemoveGradeCommand(Guid gradeId)
        {
            GradeId = gradeId;
        }
    }
}
