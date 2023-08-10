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
    internal class ExamTask_ClassConfiguration : EntityTypeConfigurationBase<ExamTask_Class>
    {
        public override void Configure(EntityTypeBuilder<ExamTask_Class> builder)
        {
            base.Configure(builder);
            builder.ToTable(DatabaseSchema.ExamTask_Class);
            builder.Property(t => t.Id).ValueGeneratedNever();

            builder.Property(v => v.ExamTaskId)
               .IsRequired();
            builder.Property(v => v.ClassId)
             .IsRequired();
        }
    }
}
