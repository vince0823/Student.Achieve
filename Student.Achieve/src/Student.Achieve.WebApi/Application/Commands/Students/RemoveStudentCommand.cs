using Fabricdot.Infrastructure.Commands;
using System;

namespace Student.Achieve.WebApi.Application.Commands.Students
{
    public class RemoveStudentCommand:Command
    {
        public Guid StudentId { get; set; }
        public RemoveStudentCommand(Guid studentId)
        {
            StudentId = studentId;
        }
    }
}
