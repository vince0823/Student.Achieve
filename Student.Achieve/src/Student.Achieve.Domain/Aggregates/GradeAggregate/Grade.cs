﻿using Fabricdot.Domain.Entities;
using Fabricdot.Domain.SharedKernel;
using Student.Achieve.Domain.Aggregates.UserAggregate;
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
        public bool IsGraduated { get; private set; } = false;
        /// <summary>
        /// 年级主任
        /// </summary>
        public Guid? DutyUserID {  get; private set; }
        //public virtual User User { get; private set; } = default!;

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

        public void Graduated()
        {
            IsGraduated = true;
        }

        public void Update(string gradeName, int enrollmenYear, Guid? dutyUserID)
        {
            GradeName = gradeName;
            EnrollmenYear = enrollmenYear;
            DutyUserID = dutyUserID;
        }
    }
}
