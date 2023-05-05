using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using Student.Achieve.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Grades
{
    public class RemoveGradeCommandHandler : CommandHandler<RemoveGradeCommand, Guid>
    {
       private readonly IGradeRepository _gradeRepository;
        public RemoveGradeCommandHandler(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public override async Task<Guid> ExecuteAsync(RemoveGradeCommand command, CancellationToken cancellationToken)
        {
            var grade=await _gradeRepository.GetByIdAsync(command.GradeId,cancellationToken);
            Guard.Against.Null(grade, nameof(grade));
            await _gradeRepository.DeleteAsync(grade,cancellationToken);
            return grade.Id;
        }
    }
}
