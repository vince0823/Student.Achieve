using Fabricdot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Aggregates.ExamTaskAggregate
{
    public class ExamTask_Class : AuditEntity<Guid>
    {
        public Guid ExamTaskId { get; private set; }
        public Guid ClassId { get; private set; }
        public ExamTask_Class() { }
        public ExamTask_Class(Guid id, Guid examTaskId, Guid classId)
        {
            Id = id;
            ClassId = classId;
            ExamTaskId = examTaskId;
        }
    }
}
