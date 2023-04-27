using Ardalis.Specification;
using Student.Achieve.Domain.Aggregates.TeacherAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Specifications
{
    public class PagedTeacherSpec : Specification<Teacher>
    {

        public PagedTeacherSpec(int offset, int size, string teacherName, string phoneNUmber)
        {
            teacherName ??= "";
            phoneNUmber ??= "";

            Query.Where(v => v.TeacherName.Contains(teacherName));
            Query.Where(v => v.PhoneNumber.Contains(phoneNUmber))
                .OrderByDescending(v => v.CreationTime);
            Query.Skip(offset)
                .Take(size);

        }
    }
}
