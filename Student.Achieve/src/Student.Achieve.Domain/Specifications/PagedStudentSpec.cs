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
    public class PagedStudentSpec : Specification<Domain.Aggregates.StudentAggregate.Student>
    {
        public PagedStudentSpec(int offset, int size, string studentName)
        {
            studentName ??= "";
            Query.Where(v => v.StudentName.Contains(studentName))
                .Include(v => v.Class)
                .OrderByDescending(v => v.CreationTime);
            Query.Skip(offset)
                .Take(size);

        }
    }
}
