using Fabricdot.Infrastructure.Commands;
using System;

namespace Student.Achieve.WebApi.Application.Commands.Grades
{
    public class GraduateGradeCommand : Command<Guid>
    {
        public Guid GradeId { get; set; }
        public GraduateGradeCommand(Guid gradeId)
        {
            GradeId = gradeId;
        }
    }
}
