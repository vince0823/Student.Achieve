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

        public ExamTaskFilter(string taskName, Guid id)
        {

            Query.Where(t => t.TaskName == taskName && t.Id != id);
        }
        public ExamTaskFilter(Guid id)
        {
            Query.Where(t => t.Id == id)
                .Include(t => t.examTask_Courses)
                .Include(t => t.examTask_Classes);
        }


    }
}
