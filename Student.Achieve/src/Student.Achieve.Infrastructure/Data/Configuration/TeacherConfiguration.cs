using Fabricdot.Infrastructure.EntityFrameworkCore.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student.Achieve.Domain.Aggregates.TeacherAggregate;
using Student.Achieve.Domain.Aggregates.TenantAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Data.Configuration
{
    public class TeacherConfiguration : EntityTypeConfigurationBase<Teacher>
    {
        public override void Configure(EntityTypeBuilder<Teacher> builder)
        {
            base.Configure(builder);
            builder.ToTable(DatabaseSchema.Teacher);
            builder.Property(v => v.TeacherName)
                   .IsRequired();
            builder.Property(v => v.TeacherEmail)
                   .IsRequired();
            builder.Property(v => v.PhoneNumber).IsRequired();
            builder.HasIndex(v => v.TeacherName);
        }
    }
}
