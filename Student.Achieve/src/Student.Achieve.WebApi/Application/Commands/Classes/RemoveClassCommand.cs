using Fabricdot.Infrastructure.Commands;
using System;

namespace Student.Achieve.WebApi.Application.Commands.Classes
{
    public class RemoveClassCommand : Command<Guid>
    {
        public Guid ClassId { get; set; }
        public RemoveClassCommand(Guid classId)
        {
            ClassId = classId;
        }
    }
}
