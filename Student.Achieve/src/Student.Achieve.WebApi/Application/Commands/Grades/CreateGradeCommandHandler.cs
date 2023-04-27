using Fabricdot.Core.UniqueIdentifier;
using Fabricdot.Domain.Services;
using Fabricdot.Domain.SharedKernel;
using Fabricdot.Identity.Domain.Repositories;
using Fabricdot.Infrastructure.Commands;
using Fabricdot.MultiTenancy.Abstractions;
using Student.Achieve.Domain.Aggregates.GradeAggregate;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Shared.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Grades
{
    public class CreateGradeCommandHandler : CommandHandler<CreateGradeCommand, Guid>
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IGuidGenerator _guidGenerator;
        private readonly ICurrentTenant _currentTenant;
        private readonly IUserRepository<User> _userRepository;
        public CreateGradeCommandHandler(IGradeRepository gradeRepository, IGuidGenerator guidGenerator, ICurrentTenant currentTenant, IUserRepository<User> userRepository)
        {
            _gradeRepository = gradeRepository;
            _guidGenerator = guidGenerator;
            _currentTenant = currentTenant;
            _userRepository = userRepository;
        }
        public override async Task<Guid> ExecuteAsync(CreateGradeCommand command, CancellationToken cancellationToken)
        {
            if (command.DutyUserID is not null)
            {
                if (await _userRepository.GetByIdAsync((Guid)command.DutyUserID, cancellationToken) is null)
                {
                    throw new CustomException("未找到该年级负责人");
                }
            }
            var grade = new Grade(_guidGenerator.Create(), _currentTenant.Id, command.GradeName, command.EnrollmenYear, command.DutyUserID);
            await _gradeRepository.AddAsync(grade, cancellationToken);
            return grade.Id;
        }
    }
}
