using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Student.Achieve.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Teachers
{
    public class RemoveTeacherCommandHandler : CommandHandler<RemoveTeacherCommand>
    {

        private readonly ITeacherRepository _teacherRepository;
        public RemoveTeacherCommandHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async override Task<Unit> ExecuteAsync(RemoveTeacherCommand command, CancellationToken cancellationToken)
        {
            var teacher = await _teacherRepository.GetByIdAsync(command.TeacherId);
            Guard.Against.Null(teacher, nameof(teacher));
            await _teacherRepository.DeleteAsync(teacher, cancellationToken);
            return Unit.Value;
        }
    }
}
