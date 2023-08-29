using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Specifications
{
    public class StudentFilter : Specification<Domain.Aggregates.StudentAggregate.Student>
    {
        public StudentFilter(Guid classId)
        {
            Query.Where(v =>  v.ClassId== classId);
            Query.Include(v => v.Class);

        }
    }
}
