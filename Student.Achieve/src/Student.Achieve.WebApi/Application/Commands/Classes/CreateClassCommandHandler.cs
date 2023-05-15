using Ardalis.GuardClauses;
using Fabricdot.Core.UniqueIdentifier;
using Fabricdot.Domain.Services;
using Fabricdot.Identity.Domain.Repositories;
using Fabricdot.Infrastructure.Commands;
using Fabricdot.MultiTenancy.Abstractions;
using Student.Achieve.Domain.Aggregates.ClassAggregate;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Shared.Exceptions;
using Student.Achieve.Domain.Specifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Classes
{
    public class CreateClassCommandHandler : CommandHandler<CreateClassCommand, Guid>
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IGuidGenerator _guidGenerator;
        private readonly ICurrentTenant _currentTenant;
        private readonly IUserRepository<User> _userRepository;
        private readonly IClassRepository _classRepository;
        public CreateClassCommandHandler(IGradeRepository gradeRepository, IGuidGenerator guidGenerator, ICurrentTenant currentTenant, IUserRepository<User> userRepository, IClassRepository classRepository)
        {
            _gradeRepository = gradeRepository;
            _guidGenerator = guidGenerator;
            _currentTenant = currentTenant;
            _userRepository = userRepository;
            _classRepository = classRepository;
        }

        public override async Task<Guid> ExecuteAsync(CreateClassCommand command, CancellationToken cancellationToken)
        {
            var grade = await _gradeRepository.GetByIdAsync(command.GradeId, cancellationToken);
            Guard.Against.Null(grade, nameof(grade));
            if (command.DutyUserId is not null)
            {
                if (await _userRepository.GetByIdAsync((Guid)command.DutyUserId, cancellationToken) is null)
                {
                    throw new CustomException("未找到该班级班主任");
                }
            }
            //同一年级是否存在多个相同班级
            if (await _classRepository.AnyAsync(new ClassFilterSpec(grade.Id, command.ClassName), cancellationToken))
            {
                throw new CustomException("该年级已存在相同名称的班级");
            }
            var selectClass = new Class(_guidGenerator.Create(), _currentTenant.Id, command.ClassName, command.GradeId, command.DutyUserId);
            await _classRepository.AddAsync(selectClass, cancellationToken);
            return selectClass.Id;
        }
    }
}
