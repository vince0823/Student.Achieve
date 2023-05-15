using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.WebApi.Application.Commands.Grades;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Student.Achieve.WebApi.Application.Commands.Classes
{
    public class RemoveClassCommandHandler : CommandHandler<RemoveClassCommand, Guid>
    {
        private readonly IClassRepository _classRepository;
        public RemoveClassCommandHandler(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public override async Task<Guid> ExecuteAsync(RemoveClassCommand command, CancellationToken cancellationToken)
        {
            var selectClass = await _classRepository.GetByIdAsync(command.ClassId, cancellationToken);
            Guard.Against.Null(selectClass, nameof(selectClass));
            await _classRepository.DeleteAsync(selectClass, cancellationToken);
            return selectClass.Id;
        }
    }
}
