using Ardalis.Specification;
using Student.Achieve.Domain.Aggregates.ClassAggregate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Specifications
{
    public class StudentSpec : Specification<Domain.Aggregates.StudentAggregate.Student>
    {
        public StudentSpec(Guid studentId)
        {
            Query.Where(v => v.Id == studentId);
            Query.Include(v => v.Class);

        }
    }
}
