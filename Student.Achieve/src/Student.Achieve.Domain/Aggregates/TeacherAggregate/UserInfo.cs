using Student.Achieve.Domain.Aggregates.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Aggregates.TeacherAggregate
{
    public class UserInfo
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string GivenName { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public Guid TargetId { get; set; }
    }
}
