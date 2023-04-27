using Fabricdot.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Events
{
    public class UserUpdateEvent : DomainEventBase
    {
        public Guid TargetId { get; set; }
        public string GivenName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public UserUpdateEvent(Guid targetId, string giveName, string phoneNumber, string email)
        {

            TargetId = targetId;
            GivenName = giveName;
            PhoneNumber = phoneNumber;
            Email = email;

        }
    }
}
