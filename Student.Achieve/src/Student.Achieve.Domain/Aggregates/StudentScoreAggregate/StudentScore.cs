using Fabricdot.Domain.Entities;
using Fabricdot.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Aggregates.StudentScoreAggregate
{
    public class StudentScore : FullAuditAggregateRoot<Guid>
    {
        public Guid ExamTaskId { get; private set; }
        public Guid CourseId {  get; private set; }
        public Guid StudentId { get; private set; }
        public decimal Score { get; private set; } = 0;

        private StudentScore()
        {

        }
        public StudentScore(Guid id,Guid examTaskId,Guid courseId,Guid studentId,decimal score)
        {
            Id = id;
            ExamTaskId = examTaskId;
            CourseId = courseId;
            StudentId = studentId;
            Score = score;

        }
    }
}
