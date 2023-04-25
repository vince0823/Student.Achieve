using Fabricdot.Domain.Events;
using Student.Achieve.Domain.Aggregates.TeacherAggregate;
using Student.Achieve.Domain.Aggregates.TenantAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Events
{
    public class UserCreateEvent : DomainEventBase
    {
        public Guid TenantId { get; }

        public UserInfo UserInfo { get; }

        public UserCreateEvent(Guid tenantId, UserInfo userInfo)
        {
            TenantId = tenantId;
            UserInfo = userInfo;
        }
    }
}
