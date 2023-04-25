using Fabricdot.Infrastructure.EntityFrameworkCore.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student.Achieve.Domain.Aggregates.ClassAggregate;
using Student.Achieve.Domain.Aggregates.GradeAggregate;
using Student.Achieve.Domain.Aggregates.TenantAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Data.Configuration
{
    public class ClassConfiguration : EntityTypeConfigurationBase<Class>
    {
        public override void Configure(EntityTypeBuilder<Class> builder)
        {
            base.Configure(builder);
            builder.ToTable(DatabaseSchema.Class);
            builder.Property(v => v.ClassName)
                   .IsRequired();
            builder.HasIndex(v => v.ClassName);
            builder.HasIndex(v => v.GradeId);
        }
    }
}
