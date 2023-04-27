using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using Student.Achieve.Domain.Events;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.WebApi.Application.Commands.Roles;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Teachers
{
    public class UpdateTeacherCommandHandler : CommandHandler<UpdateTeacherCommand>
    {
        public readonly ITeacherRepository _teacherRepository;
        public UpdateTeacherCommandHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async override Task<Guid> ExecuteAsync(UpdateTeacherCommand command, CancellationToken cancellationToken)
        {
            var teacher = await _teacherRepository.GetByIdAsync(command.TeacherId, cancellationToken);
            Guard.Against.Null(teacher, nameof(teacher));
            teacher.Update(command.TeacherName, command.TeacherEmail, command.PhoneNumber);
            teacher.AddDomainEvent(new UserUpdateEvent(teacher.Id, command.TeacherName, command.PhoneNumber, command.TeacherEmail));
            await _teacherRepository.UpdateAsync(teacher, cancellationToken);
            return teacher.Id;
        }
    }
}
