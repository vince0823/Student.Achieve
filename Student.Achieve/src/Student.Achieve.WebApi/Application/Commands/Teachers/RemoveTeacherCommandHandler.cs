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
            var role = await _teacherRepository.GetByIdAsync(command.TeacherId);
            Guard.Against.Null(role, nameof(role));
            await _teacherRepository.DeleteAsync(role);
            return Unit.Value;
        }
    }
}
