using Fabricdot.Domain.Entities;
using Fabricdot.Domain.SharedKernel;
using Student.Achieve.Domain.Aggregates.GradeAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Aggregates.ClassAggregate
{
    public class Class : FullAuditAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; private set; }
        public string ClassName { get; private set; }
        public Guid? DutyUserId { get; private set; }
        public Guid GradeId { get; private set; }
        public virtual Grade Grade { get; private set; } = default!;

        private Class() { }

        public Class(Guid id, Guid? tenantId, string className, Guid gradeId, Guid? dutyUserId)
        {
            Id = id;
            TenantId = tenantId;
            ClassName = className;
            GradeId = gradeId;
            DutyUserId = dutyUserId;
        }
    }
}
