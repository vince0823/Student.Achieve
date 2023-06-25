using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using Student.Achieve.Domain.Aggregates.TeacherAggregate;
using Student.Achieve.Domain.Events;
using Student.Achieve.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Students
{
    public class UpdateStudentCommandHandler : CommandHandler<UpdateStudentCommand>
    {
        public readonly IStudentRepository _studentRepository;
        public UpdateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public override async Task<Guid> ExecuteAsync(UpdateStudentCommand command, CancellationToken cancellationToken)
        {

            var student = await _studentRepository.GetByIdAsync(command.StudentId, cancellationToken);
            Guard.Against.Null(student, nameof(student));
            student.Update(command.StudentName, command.StudentEmail, command.PhoneNumber);
            student.AddDomainEvent(new UserUpdateEvent(student.Id, command.StudentName, command.PhoneNumber, command.StudentEmail));
            await _studentRepository.UpdateAsync(student, cancellationToken);
            return student.Id;
        }
    }
}
