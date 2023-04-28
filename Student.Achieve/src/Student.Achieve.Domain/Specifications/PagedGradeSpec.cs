using Ardalis.Specification;
using Student.Achieve.Domain.Aggregates.GradeAggregate;
using Student.Achieve.Domain.Aggregates.TeacherAggregate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Specifications
{
    public class PagedGradeSpec : Specification<Grade>
    {

        public PagedGradeSpec(int offset, int size, string gradeName)
        {
            gradeName ??= "";
            Query.Where(v => v.GradeName.Contains(gradeName))
                .Include(v => v.User)
                .OrderByDescending(v => v.CreationTime);
            Query.Skip(offset)
                .Take(size);

        }
    }
}
