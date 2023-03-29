using Fabricdot.Domain.Auditing;
using Fabricdot.Infrastructure.EntityFrameworkCore.Configurations;
using Fabricdot.MultiTenancy.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student.Achieve.Domain.Aggregates.TenantAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Data.Configuration
{
    internal class TenantConfiguration : EntityTypeConfigurationBase<Tenant>
    {
        public override void Configure(EntityTypeBuilder<Tenant> builder)
        {
            base.Configure(builder);
            builder.ToTable(DatabaseSchema.Tenant);
            builder.Property(v => v.Name)
                   .IsRequired();
            builder.Property(v => v.NormalizedName)    
                   .IsRequired();
            builder.Property(v => v.OwnerId).IsRequired();
            builder.Property(v => v.IsEnabled)
                   .IsRequired();
        }
    }
}
