using Fabricdot.Domain.Entities;
using Fabricdot.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Aggregates.TeacherAggregate
{
    public class Teacher : FullAuditAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; private set; }
        public string TeacherName { get; private set; }
        public string TeacherEmail { get; private set; }
        public string PhoneNumber { get; private set; }
        private Teacher()
        {

        }
        public Teacher(Guid id, Guid? tenantId, string teacherName, string teacherEmail, string phoneNumber)
        {
            Id = id;
            TenantId = tenantId;
            TeacherName = teacherName;
            TeacherEmail = teacherEmail;
            PhoneNumber = phoneNumber;
        }
    }
}
