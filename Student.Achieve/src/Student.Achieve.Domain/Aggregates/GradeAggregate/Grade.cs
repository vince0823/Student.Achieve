using Fabricdot.Domain.Entities;
using Fabricdot.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Aggregates.GradeAggregate
{
    public class Grade : FullAuditAggregateRoot<Guid>, IMultiTenant
    {

        public Guid? TenantId { get; private set; }
        public string GradeName { get; private set; }
        /// <summary>
        /// 入学年份
        /// </summary>
        public int EnrollmenYear { get; private set; }

        /// <summary>
        /// 年级主任
        /// </summary>
        public Guid? DutyUserID {  get; private set; }

        private Grade()
        {

        }
        public Grade(Guid id,Guid? tenantId, string gradeName, int enrollmenYear, Guid? dutyUserID)
        {
            Id = id;
            TenantId = tenantId;
            GradeName = gradeName;
            EnrollmenYear = enrollmenYear;
            DutyUserID = dutyUserID;
        }
    }
}
