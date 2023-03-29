using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Aggregates.TenantAggregate
{
    public class TenantOwnerInfo
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string GivenName { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }
    }
}
