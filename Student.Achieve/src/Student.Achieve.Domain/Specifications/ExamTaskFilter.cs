using Ardalis.Specification;
using Student.Achieve.Domain.Aggregates.CourseAggregate;
using Student.Achieve.Domain.Aggregates.ExamTaskAggregate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Specifications
{
    public class ExamTaskFilter : Specification<ExamTask>
    {
        public ExamTaskFilter(string taskName)
        {

            Query.Where(t => t.TaskName == taskName);
        }


    }
}
