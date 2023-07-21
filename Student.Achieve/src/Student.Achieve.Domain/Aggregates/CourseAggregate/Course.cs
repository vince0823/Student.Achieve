using Ardalis.GuardClauses;
using Fabricdot.Domain.Entities;
using Fabricdot.Domain.SharedKernel;
using Student.Achieve.Domain.Aggregates.GradeAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Student.Achieve.Domain.Aggregates.CourseAggregate
{
    public class Course : FullAuditAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public string CourseName { get; set; }
        private Course() { }
        public Course(Guid id, Guid? tenantId, string courseName)
        {
            TenantId = tenantId;
            CourseName = Guard.Against.NullOrWhiteSpace(courseName, nameof(courseName));
            Id = id;
        }

        public void Update(string courseName)
        {
            CourseName = Guard.Against.NullOrWhiteSpace(courseName, nameof(courseName));
        }
    }
}
