using Ardalis.Specification;
using Student.Achieve.Domain.Aggregates.TeacherAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Specifications
{
    public class TeacherSpec : Specification<Teacher>
    {
        public TeacherSpec(Guid tenantId) {

            Query.Where(t => t.TenantId == tenantId);
        }
    }
}
