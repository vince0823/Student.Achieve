using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using MediatR;
using Student.Achieve.Domain.Aggregates.TeacherAggregate;
using Student.Achieve.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Students
{
    public class RemoveStudentCommandHandler : CommandHandler<RemoveStudentCommand>
    {
        public readonly IStudentRepository _studentRepository;
        public RemoveStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public override async Task<Unit> ExecuteAsync(RemoveStudentCommand command, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(command.StudentId, cancellationToken);
            Guard.Against.Null(student, nameof(student));
            await _studentRepository.DeleteAsync(student, cancellationToken);
            return Unit.Value;
        }
    }
}
