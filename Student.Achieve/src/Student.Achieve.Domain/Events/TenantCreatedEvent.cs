using Fabricdot.Domain.Events;
using Student.Achieve.Domain.Aggregates.TenantAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Events
{
    public class TenantCreatedEvent : DomainEventBase
    {
        public Guid TenantId { get; }

        public TenantOwnerInfo TenantOwner { get; }

        public TenantCreatedEvent(
            Guid tenantId,
            TenantOwnerInfo tenantOwner)
        {
            TenantId = tenantId;
            TenantOwner = tenantOwner;
        }
    }
}
