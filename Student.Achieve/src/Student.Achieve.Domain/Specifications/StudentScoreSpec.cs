using Ardalis.Specification;
using Student.Achieve.Domain.Aggregates.StudentScoreAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Specifications
{
    public class StudentScoreSpec : Specification<StudentScore>
    {
        public StudentScoreSpec(Guid taskId)
        {

            Query.Where(t => t.ExamTaskId == taskId);
        }
    }
}
