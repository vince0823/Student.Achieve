using Ardalis.Specification;
using Student.Achieve.Domain.Aggregates.ClassAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Specifications
{
    public class ClassFilterSpec : Specification<Class>
    {
        public ClassFilterSpec(Guid gradeId)
        {
            Query.AsNoTracking().Where(v => v.GradeId == gradeId);
        }

        public ClassFilterSpec(Guid gradeId, string className)
        {
            Query.AsNoTracking().Where(v => v.GradeId == gradeId && v.ClassName == className);
        }
        public ClassFilterSpec(Guid gradeId, string className, Guid classId)
        {
            Query.AsNoTracking().Where(v => v.GradeId == gradeId && v.ClassName == className && v.Id != classId);
        }
        public ClassFilterSpec(HashSet<Guid> gradeIds)
        {
            Query.AsNoTracking().Where(v => gradeIds.Contains(v.GradeId));
        }
    }
}
