using Ardalis.GuardClauses;
using Fabricdot.Identity.Domain.Repositories;
using Fabricdot.Infrastructure.Commands;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Shared.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Grades
{
    public class UpdateGradeCommandHandler : CommandHandler<UpdateGradeCommand, Guid>
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IUserRepository<User> _userRepository;
        public UpdateGradeCommandHandler(IGradeRepository gradeRepository, IUserRepository<User> userRepository)
        {
            _gradeRepository = gradeRepository;
            _userRepository = userRepository;
        }


        public override async Task<Guid> ExecuteAsync(UpdateGradeCommand command, CancellationToken cancellationToken)
        {
            var grade = await _gradeRepository.GetByIdAsync(command.GradeId, cancellationToken);
            Guard.Against.Null(grade, nameof(grade));
            if (command.DutyUserID is not null)
            {
                if (await _userRepository.GetByIdAsync((Guid)command.DutyUserID, cancellationToken) is null)
                {
                    throw new CustomException("未找到该年级负责人");
                }
            }
            grade.Update(command.GradeName, command.EnrollmenYear, command.DutyUserID);
            await _gradeRepository.UpdateAsync(grade, cancellationToken);
            return grade.Id;

        }
    }
}
