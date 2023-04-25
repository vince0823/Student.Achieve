using Fabricdot.Infrastructure.EntityFrameworkCore.Configurations;
using Fabricdot.Infrastructure.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student.Achieve.Domain.Aggregates.TenantAggregate;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Data.Configuration
{
    public class UserConfiguration : EntityTypeConfigurationBase<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ConfigureEnumeration<UserType>(nameof(UserType));
        }
    }

}
