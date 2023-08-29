using Ardalis.GuardClauses;
using Fabricdot.Core.UniqueIdentifier;
using Fabricdot.Infrastructure.Commands;
using Student.Achieve.Domain.Aggregates.CourseAggregate;
using Student.Achieve.Domain.Aggregates.StudentAggregate;
using Student.Achieve.Domain.Aggregates.StudentScoreAggregate;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Shared.Exceptions;
using Student.Achieve.Domain.Specifications;
using Student.Achieve.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.ExamTasks
{
    public class UpdateExamTaskCommandHandler : CommandHandler<UpdateExamTaskCommand, Guid>
    {
        private readonly IExamTaskRepository _examTaskRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentScoreRepository _studentScoreRepository;
        private readonly AppDbContext _appDbContext;
        private readonly IGuidGenerator _guidGenerator;

        public UpdateExamTaskCommandHandler(IExamTaskRepository examTaskRepository, IStudentRepository studentRepository, IStudentScoreRepository studentScoreRepository, AppDbContext appDbContext, IGuidGenerator guidGenerator)
        {
            _examTaskRepository = examTaskRepository;
            _studentRepository = studentRepository;
            _studentScoreRepository = studentScoreRepository;
            _appDbContext = appDbContext;
            _guidGenerator = guidGenerator;
        }

        public override async Task<Guid> ExecuteAsync(UpdateExamTaskCommand command, CancellationToken cancellationToken)
        {
            Guard.Against.InvalidInput(command.CourseIds, nameof(command.CourseIds), v => v.Count > 0);
            Guard.Against.InvalidInput(command.ClassIds, nameof(command.ClassIds), v => v.Count > 0);
            var oldfilter = new ExamTaskFilter(command.TaskName, command.Id);
            var task = await _examTaskRepository.GetBySpecAsync(oldfilter, cancellationToken);
            if (task != null)
            {
                throw new CustomException($"系统内已存在{command.TaskName}考试任务");
            }
            var filter = new ExamTaskFilter(command.ExamTaskId);
            var oldTask = await _examTaskRepository.GetBySpecAsync(filter, cancellationToken);
            Guard.Against.Null(oldTask, nameof(oldTask));
            oldTask.Update(command.TaskName, command.StartTime, command.EndTime, command.AcademicYear, command.Semester);
            oldTask.RemoveExamTask_Class(command.ExamTaskId);
            oldTask.RemoveExamTask_Course(command.ExamTaskId);
            command.CourseIds.ForEach(v =>
            {
                oldTask.AddExamTask_Course(_guidGenerator.Create(), oldTask.Id, v);

            });
            command.ClassIds.ForEach(v =>
            {
                oldTask.AddExamTask_Classes(_guidGenerator.Create(), oldTask.Id, v);
            });
            var scoreSpec = new StudentScoreSpec(command.ExamTaskId);
            var scores = await _studentScoreRepository.ListAsync(scoreSpec, cancellationToken);
            await _appDbContext.StudentScores.BulkDeleteAsync(scores);
            //获取班级内的学生
            var studentSpec = new StudentSpec(command.ClassIds);
            var students = await _studentRepository.ListAsync(studentSpec, cancellationToken);
            var scoreList = new List<StudentScore>();
            command.CourseIds.ForEach(c =>
            {
                students.ForEach(v =>
                {
                    var score = new StudentScore(_guidGenerator.Create(), oldTask.Id, c, v.Id, 0);
                    scoreList.Add(score);
                });

            });
            //如果有外键  无法插入
            await _appDbContext.StudentScores.BulkInsertAsync(scoreList);
            await _appDbContext.SaveChangesAsync();
            await _examTaskRepository.UpdateAsync(oldTask, cancellationToken);
            return oldTask.Id;
        }
    }
}
