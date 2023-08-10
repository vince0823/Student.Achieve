using Fabricdot.Infrastructure.EntityFrameworkCore.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student.Achieve.Domain.Aggregates.ExamTaskAggregate;
using Student.Achieve.Domain.Aggregates.GradeAggregate;
using Student.Achieve.Domain.Aggregates.StudentScoreAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Data.Configuration
{
    internal class StudentScoreConfiguration : EntityTypeConfigurationBase<StudentScore>
    {
        public override void Configure(EntityTypeBuilder<StudentScore> builder)
        {
            base.Configure(builder);
            builder.ToTable(DatabaseSchema.StudentScore);
            builder.Property(t => t.Id).ValueGeneratedNever();
            builder.HasOne<ExamTask>()
              .WithMany()
              .HasForeignKey(v => v.ExamTaskId)
              .IsRequired();
            builder.HasOne<Student.Achieve.Domain.Aggregates.StudentAggregate.Student>()
             .WithMany()
             .HasForeignKey(v => v.StudentId)
             .IsRequired();

            builder.Property(v => v.Score)
             .IsRequired();

            builder.HasIndex(v => new { v.StudentId, v.ExamTaskId });
            builder.HasIndex(v => v.Score);
        }
    }
}
