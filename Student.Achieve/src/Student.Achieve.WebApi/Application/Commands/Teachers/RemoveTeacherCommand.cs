using Fabricdot.Infrastructure.Commands;
using System;

namespace Student.Achieve.WebApi.Application.Commands.Teachers
{
    public class RemoveTeacherCommand : Command
    {
        public Guid TeacherId { get; set; }
        public RemoveTeacherCommand(Guid teacherId)
        {
            TeacherId = teacherId;
        }
    }
}
