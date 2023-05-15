using Ardalis.Specification;
using Student.Achieve.Domain.Aggregates.ClassAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Specifications
{
    public class PagedClassSpec:Specification<Class>
    {
        public PagedClassSpec(int offset, int size, string className)
        {
            className ??= "";
            Query.Where(v => v.ClassName.Contains(className))
                .Include(v => v.Grade)
                .OrderByDescending(v => v.CreationTime);
            Query.Skip(offset)
                .Take(size);

        }
    }
}
