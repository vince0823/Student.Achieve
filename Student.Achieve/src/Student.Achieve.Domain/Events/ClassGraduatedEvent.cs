using Fabricdot.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Events
{
    public class ClassGraduatedEvent : DomainEventBase
    {
        public Guid GradeId { get; set; }
        public ClassGraduatedEvent(Guid gradeId)
        {
            GradeId = gradeId;
        }

    }
}
