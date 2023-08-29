using Ardalis.GuardClauses;
using Fabricdot.Domain.Entities;
using Fabricdot.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Student.Achieve.Domain.Aggregates.ExamTaskAggregate
{
    public class ExamTask : FullAuditAggregateRoot<Guid>, IMultiTenant
    {
        private readonly List<ExamTask_Course> _examTask_Courses = new();
        private readonly List<ExamTask_Class> _examTask_Classes = new();
        public Guid? TenantId { get; private set; }
        public string TaskName { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public string AcademicYear { get; private set; }
        public Semester Semester { get; private set; }

        public IReadOnlyCollection<ExamTask_Course> examTask_Courses => _examTask_Courses.AsReadOnly();

        public IReadOnlyCollection<ExamTask_Class> examTask_Classes => _examTask_Classes.AsReadOnly();

        private ExamTask()
        {

        }
        public ExamTask(Guid id, Guid? tenantId, string taskName, DateTime startTime, DateTime endTime, string academicYear, Semester semester)
        {
            Id = id;
            TenantId = tenantId;
            TaskName = taskName;
            StartTime = startTime;
            EndTime = endTime;
            AcademicYear = academicYear;
            Semester = semester;
        }

        public void Update(string taskName, DateTime startTime, DateTime endTime, string academicYear, Semester semester)
        {
            TaskName = Guard.Against.NullOrWhiteSpace(taskName, nameof(taskName)); ;
            StartTime = Guard.Against.OutOfSQLDateRange(startTime, nameof(startTime));
            EndTime = Guard.Against.OutOfSQLDateRange(endTime, nameof(endTime));
            AcademicYear = Guard.Against.NullOrWhiteSpace(academicYear, nameof(academicYear));
            Semester = semester;

        }

        public void AddExamTask_Course(Guid task_CourseId, Guid taskId, Guid courseId)
        {

            var item = new ExamTask_Course(task_CourseId, taskId, courseId);
            _examTask_Courses.Add(item);
        }
        public void RemoveExamTask_Course(Guid taskId)
        {
            _examTask_Courses.RemoveAll(v => v.ExamTaskId == taskId);
        }

        public void AddExamTask_Classes(Guid task_ClassId, Guid taskId, Guid classId)
        {

            var item = new ExamTask_Class(task_ClassId, taskId, classId);
            _examTask_Classes.Add(item);


        }

        public void RemoveExamTask_Class(Guid taskId)
        {
            _examTask_Classes.RemoveAll(v => v.ExamTaskId == taskId);
        }
    }
}
