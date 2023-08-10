using Fabricdot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Aggregates.ExamTaskAggregate
{
    public class ExamTask_Course : AuditEntity<Guid>
    {
        public Guid ExamTaskId { get; private set; }
        public Guid CourseId { get; private set; }

        public ExamTask_Course()
        {

        }
        public ExamTask_Course(Guid id, Guid examTaskId, Guid courseId)
        {
            Id = id;
            ExamTaskId = examTaskId;
            CourseId = courseId;
        }
    }
}
