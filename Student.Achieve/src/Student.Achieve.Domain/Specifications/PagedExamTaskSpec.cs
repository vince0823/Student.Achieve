using Ardalis.Specification;
using Fabricdot.Domain.ValueObjects;
using Student.Achieve.Domain.Aggregates.ExamTaskAggregate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Student.Achieve.Domain.Specifications
{
    public class PagedExamTaskSpec : Specification<ExamTask>
    {
        public PagedExamTaskSpec(int offset, int size, string taskName, string academicYear, int? semester)
        {
            taskName ??= "";
            academicYear ??= "";
            if (semester is not null)
                Query.Where(v => Enumeration.FromValue<Semester>(semester.Value) == v.Semester);
            Query.Where(v => v.TaskName.Contains(taskName) && v.AcademicYear.Contains(academicYear))
                .Include(v => v.examTask_Classes)
                .Include(v => v.examTask_Courses)
                .OrderByDescending(v => v.CreationTime);
            Query.Skip(offset)
                .Take(size);

        }
    }
}
