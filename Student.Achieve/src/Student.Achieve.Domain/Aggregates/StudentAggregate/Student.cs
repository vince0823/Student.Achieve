using Fabricdot.Domain.Entities;
using Fabricdot.Domain.SharedKernel;
using Student.Achieve.Domain.Aggregates.ClassAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Aggregates.StudentAggregate
{
    public class Student : FullAuditAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; private set; }
        public string StudentName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string StudentEmail { get; private set; }
        public Guid ClassId { get; private set; }
        public virtual Class Class { get; private set; }
        private Student() { }
        public Student(Guid id, Guid? tenantId, string studentName, string phoneNumber, string email, Guid classId)
        {
            Id = id;
            TenantId = tenantId;
            StudentName = studentName;
            PhoneNumber = phoneNumber;
            StudentEmail = email;
            ClassId = classId;
        }
    }
}
