using Ardalis.Specification;
using Student.Achieve.Domain.Aggregates.CourseAggregate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Specifications
{
    public class CourseFilter : Specification<Course>
    {
        public CourseFilter(string coursName)
        {

            Query.Where(t => t.CourseName == coursName);
        }

        public CourseFilter(Guid courseId, string coursName)
        {
            Query.Where(t => t.Id != courseId && t.CourseName == coursName);

        }
    }
}
