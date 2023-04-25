using Fabricdot.Infrastructure.EntityFrameworkCore.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student.Achieve.Domain.Aggregates.GradeAggregate;
using Student.Achieve.Domain.Aggregates.TenantAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Data.Configuration
{
    internal class GradeConfiguration : EntityTypeConfigurationBase<Grade>
    {
        public override void Configure(EntityTypeBuilder<Grade> builder)
        {
            base.Configure(builder);
            builder.ToTable(DatabaseSchema.Grade);
            builder.Property(v => v.GradeName)
                   .IsRequired();
            builder.Property(v => v.EnrollmenYear)
                   .IsRequired();
            builder.HasIndex(v => v.GradeName);
        }
    }
}
