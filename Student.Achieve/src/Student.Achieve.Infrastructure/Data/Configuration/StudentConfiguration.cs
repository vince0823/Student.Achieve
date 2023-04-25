using Fabricdot.Infrastructure.EntityFrameworkCore.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student.Achieve.Domain.Aggregates.ClassAggregate;
using Student.Achieve.Domain.Aggregates.GradeAggregate;
using Student.Achieve.Domain.Aggregates.StudentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Data.Configuration
{
    public class StudentConfiguration : EntityTypeConfigurationBase<Student.Achieve.Domain.Aggregates.StudentAggregate.Student>
    {
        public override void Configure(EntityTypeBuilder<Student.Achieve.Domain.Aggregates.StudentAggregate.Student> builder)
        {
            base.Configure(builder);
            builder.ToTable(DatabaseSchema.Student);
            builder.Property(v => v.StudentName)
                   .IsRequired();
            builder.Property(v => v.PhoneNumber)
                   .IsRequired();
            builder.Property(v => v.StudentEmail).IsRequired();
            
            builder.HasIndex(v => v.StudentName);
            builder.HasIndex(v => v.ClassId);

        }
    }
}
