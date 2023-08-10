using Fabricdot.Infrastructure.EntityFrameworkCore.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student.Achieve.Domain.Aggregates.ExamTaskAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Data.Configuration
{
    public class ExamTask_CourseConfiguration:EntityTypeConfigurationBase<ExamTask_Course>
    {
        public override void Configure(EntityTypeBuilder<ExamTask_Course> builder)
        {
            base.Configure(builder);
            builder.ToTable(DatabaseSchema.ExamTask_Course);
            builder.Property(t => t.Id).ValueGeneratedNever();

            builder.Property(v => v.ExamTaskId)
               .IsRequired();
            builder.Property(v => v.CourseId)
             .IsRequired();
        }
    }
}
