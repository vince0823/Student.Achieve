using System;

namespace Student.Achieve.WebApi.Application.Queries.Tenants
{
    public class TenantOwnerDto
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string GivenName { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }
    }
}
