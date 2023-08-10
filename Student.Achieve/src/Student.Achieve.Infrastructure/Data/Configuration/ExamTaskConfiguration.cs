using Fabricdot.Infrastructure.EntityFrameworkCore.Configurations;
using Fabricdot.Infrastructure.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Student.Achieve.Domain.Aggregates.ExamTaskAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Data.Configuration
{
    public class ExamTaskConfiguration : EntityTypeConfigurationBase<ExamTask>
    {
        public override void Configure(EntityTypeBuilder<ExamTask> builder)
        {
            base.Configure(builder);
            builder.ToTable(DatabaseSchema.ExamTask);

            builder.Property(v => v.TaskName)
                  .IsRequired();
            builder.Property(v => v.StartTime)
                   .IsRequired();
            builder.Property(v => v.EndTime)
                 .IsRequired();
            builder.Property(v => v.AcademicYear)
                .IsRequired();
            builder.ConfigureEnumeration<Semester>(nameof(ExamTask.Semester))
                   .IsRequired();

            builder.Navigation(v => v.examTask_Courses)
               .UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.HasMany(v => v.examTask_Courses)
                   .WithOne()
                   .HasForeignKey(v => v.ExamTaskId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.Navigation(v => v.examTask_Classes)
               .UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.HasMany(v => v.examTask_Classes)
                   .WithOne()
                   .HasForeignKey(v => v.ExamTaskId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(v => new { v.TaskName, v.StartTime, v.EndTime, v.AcademicYear, v.Semester });

        }
    }
}
