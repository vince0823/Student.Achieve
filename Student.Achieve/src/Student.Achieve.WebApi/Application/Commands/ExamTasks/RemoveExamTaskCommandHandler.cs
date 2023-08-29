using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using Student.Achieve.Domain.Aggregates.CourseAggregate;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Specifications;
using Student.Achieve.Infrastructure.Data;
using Student.Achieve.WebApi.Application.Commands.Courses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.ExamTasks
{
    public class RemoveExamTaskCommandHandler : CommandHandler<RemoveExamTaskCommand, Guid>
    {
        private readonly IExamTaskRepository _examTaskRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentScoreRepository _studentScoreRepository;
        private readonly AppDbContext _appDbContext;
        public RemoveExamTaskCommandHandler(IExamTaskRepository examTaskRepository, IStudentRepository studentRepository, IStudentScoreRepository studentScoreRepository, AppDbContext appDbContext)
        {
            _examTaskRepository=examTaskRepository;
            _studentRepository=studentRepository;
            _studentScoreRepository=studentScoreRepository;
            _appDbContext=appDbContext;
        } 

        public override async Task<Guid> ExecuteAsync(RemoveExamTaskCommand command, CancellationToken cancellationToken)
        {
            var filter = new ExamTaskFilter(command.ExamTaskId);
            var oldTask = await _examTaskRepository.GetBySpecAsync(filter, cancellationToken);
            Guard.Against.Null(oldTask, nameof(oldTask));
            oldTask.RemoveExamTask_Class(command.ExamTaskId);
            oldTask.RemoveExamTask_Course(command.ExamTaskId);
            //成绩
            var scoreSpec = new StudentScoreSpec(command.ExamTaskId);
            var scores = await _studentScoreRepository.ListAsync(scoreSpec, cancellationToken);
            await _appDbContext.StudentScores.BulkDeleteAsync(scores);
            await _appDbContext.SaveChangesAsync();
            await _examTaskRepository.DeleteAsync(oldTask, cancellationToken);
            return oldTask.Id;
        }
    }
}
