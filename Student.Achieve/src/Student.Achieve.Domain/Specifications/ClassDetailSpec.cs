using Ardalis.Specification;
using Student.Achieve.Domain.Aggregates.ClassAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Specifications
{
    public class ClassDetailSpec : Specification<Class>
    {
        public ClassDetailSpec(Guid classId)
        {
            Query.Where(v => v.Id == classId);
            Query.Include(v => v.Grade);

        }
    }
}
