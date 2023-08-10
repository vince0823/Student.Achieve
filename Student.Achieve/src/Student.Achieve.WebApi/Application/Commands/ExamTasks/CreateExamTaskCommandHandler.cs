using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using Student.Achieve.WebApi.Application.Commands.Courses;
using System;
using System.Threading;
using System.Threading.Tasks;
using Student.Achieve.Domain.Specifications;
using Fabricdot.Core.UniqueIdentifier;
using Fabricdot.MultiTenancy.Abstractions;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Shared.Exceptions;
using Student.Achieve.Domain.Aggregates.ExamTaskAggregate;
using System.Collections.Generic;
using Student.Achieve.Domain.Aggregates.StudentScoreAggregate;
using Student.Achieve.Infrastructure.Data;
using Student.Achieve.Domain.Aggregates.CourseAggregate;

namespace Student.Achieve.WebApi.Application.Commands.ExamTasks
{
    public class CreateExamTaskCommandHandler : CommandHandler<CreateExamTaskCommand, Guid>
    {
        private readonly IExamTaskRepository _examTaskRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentScoreRepository _studentScoreRepository;
        private readonly AppDbContext _appDbContext;
        private readonly IGuidGenerator _guidGenerator;
        private readonly ICurrentTenant _currentTenant;

        public CreateExamTaskCommandHandler(IExamTaskRepository examTaskRepository, IGuidGenerator guidGenerator, ICurrentTenant currentTenant, IStudentRepository studentRepository, IStudentScoreRepository studentScoreRepository, AppDbContext appDbContext)
        {
            _examTaskRepository = examTaskRepository;
            _guidGenerator = guidGenerator;
            _currentTenant = currentTenant;
            _studentRepository = studentRepository;
            _studentScoreRepository = studentScoreRepository;
            _appDbContext = appDbContext;
        }

        public override async Task<Guid> ExecuteAsync(CreateExamTaskCommand command, CancellationToken cancellationToken)
        {

            Guard.Against.InvalidInput(command.CourseIds, nameof(command.CourseIds), v => v.Count > 0);
            Guard.Against.InvalidInput(command.ClassIds, nameof(command.ClassIds), v => v.Count > 0);
            var filter = new ExamTaskFilter(command.TaskName);
            var task = await _examTaskRepository.GetBySpecAsync(filter, cancellationToken);
            if (task != null)
            {
                throw new CustomException($"系统内已存在{command.TaskName}考试任务");
            }
            var newTask = new ExamTask(_guidGenerator.Create(), _currentTenant.Id, command.TaskName, command.StartTime, command.EndTime, command.AcademicYear, command.Semester);
            newTask.AddExamTask_Course(_guidGenerator.Create(), newTask.Id, command.CourseIds);
            newTask.AddExamTask_Classes(_guidGenerator.Create(), newTask.Id, command.ClassIds);
            //获取班级内的学生
            var studentSpec = new StudentSpec(command.ClassIds);
            var students = await _studentRepository.ListAsync(studentSpec, cancellationToken);
            var scores=new List<StudentScore>();
            students.ForEach(v =>
            {
                var score = new StudentScore(_guidGenerator.Create(), newTask.Id, v.Id, 0);
                scores.Add(score);
            });
            //有外键  无法插入
            await _appDbContext.StudentScores.BulkInsertAsync(scores);
            await _examTaskRepository.AddAsync(newTask, cancellationToken);
            return newTask.Id;
        }
    }
}
