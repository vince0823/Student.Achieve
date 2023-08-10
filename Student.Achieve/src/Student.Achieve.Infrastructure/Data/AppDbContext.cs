using Fabricdot.Identity.Infrastructure.Data;
using Fabricdot.PermissionGranting.Domain;
using Fabricdot.PermissionGranting.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Student.Achieve.Domain.Aggregates.ClassAggregate;
using Student.Achieve.Domain.Aggregates.CourseAggregate;
using Student.Achieve.Domain.Aggregates.ExamTaskAggregate;
using Student.Achieve.Domain.Aggregates.GradeAggregate;
using Student.Achieve.Domain.Aggregates.RoleAggregate;
using Student.Achieve.Domain.Aggregates.StudentScoreAggregate;
using Student.Achieve.Domain.Aggregates.TeacherAggregate;
using Student.Achieve.Domain.Aggregates.TenantAggregate;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using System.Reflection;

namespace Student.Achieve.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User, Role>, IPermissionGrantingDbContext
    {
        public DbSet<GrantedPermission> GrantedPermissions { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Student.Achieve.Domain.Aggregates.StudentAggregate.Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ExamTask_Class> ExamTask_Classes { get; set; }
        public DbSet<ExamTask_Course> ExamTask_Courses { get; set; }
        public DbSet<ExamTask> ExamTasks { get; set; }
        public DbSet<StudentScore> StudentScores { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.ConfigurePermissionGranting();
        }
    }
}