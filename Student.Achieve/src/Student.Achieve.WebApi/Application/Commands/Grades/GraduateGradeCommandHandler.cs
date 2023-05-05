using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using Student.Achieve.Domain.Repositories;
using System.Threading.Tasks;
using System.Threading;
using System;
using Student.Achieve.Domain.Events;

namespace Student.Achieve.WebApi.Application.Commands.Grades
{
    public class GraduateGradeCommandHandler : CommandHandler<GraduateGradeCommand, Guid>
    {
        private readonly IGradeRepository _gradeRepository;
        public GraduateGradeCommandHandler(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public override async Task<Guid> ExecuteAsync(GraduateGradeCommand command, CancellationToken cancellationToken)
        {
            var grade = await _gradeRepository.GetByIdAsync(command.GradeId, cancellationToken);
            Guard.Against.Null(grade, nameof(grade));
            grade.Graduated();
            grade.AddDomainEvent(new ClassGraduatedEvent(grade.Id), cancellationToken);
            await _gradeRepository.UpdateAsync(grade, cancellationToken);
            return grade.Id;
        }
    }
}
