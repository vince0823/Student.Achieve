using Ardalis.Specification;
using Student.Achieve.Domain.Aggregates.GradeAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Specifications
{
    public class GradeByNameSpec : Specification<Grade>
    {
        public GradeByNameSpec(string gradeName)
        {

            Query.Where(v => v.GradeName == gradeName);
        }
    }
}
