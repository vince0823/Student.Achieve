using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Data
{
    public static class DatabaseSchema
    {
        public const string Tenant = "Tenants";
        public const string Teacher = "Teachers";
        public const string Class = "Classs";
        public const string Student = "Students";
        public const string Grade = "Grades";
        public const string Course = "Courses";
        public const string ExamTask = "ExamTasks";
        public const string ExamTask_Class = "ExamTask_Classes";
        public const string ExamTask_Course = "ExamTask_Courses";
        public const string StudentScore = "StudentScores";
    }
}
