using Fabricdot.Core.UniqueIdentifier;
using Fabricdot.Infrastructure.Commands;
using Fabricdot.MultiTenancy.Abstractions;
using Student.Achieve.Domain.Aggregates.TeacherAggregate;
using Student.Achieve.Domain.Events;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Shared.Constants;
using Student.Achieve.Infrastructure.International.Converters;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Teachers
{
    public class CreateTeacherCommandHandler : CommandHandler<CreateTeacherCommand, Guid>
    {

        private readonly IPinyinConverter _pinyinConverter;
        public readonly ICurrentTenant _currentTenant;
        public readonly ITeacherRepository _teacherRepository;
        private readonly IGuidGenerator _guidGenerator;

        public CreateTeacherCommandHandler(IPinyinConverter pinyinConverter, ICurrentTenant currentTenant, ITeacherRepository teacherRepository, IGuidGenerator guidGenerator)
        {
            _pinyinConverter = pinyinConverter;
            _currentTenant = currentTenant;
            _teacherRepository = teacherRepository;
            _guidGenerator = guidGenerator;
        }
        public override async Task<Guid> ExecuteAsync(CreateTeacherCommand command, CancellationToken cancellationToken)
        {
            var userName = _pinyinConverter.ToPinyin(command.TeacherName).ToLowerInvariant();

            var teacher = new Teacher(_guidGenerator.Create(), _currentTenant.Id, command.TeacherName, command.TeacherEmail, command.PhoneNumber);
            var userInfo = new UserInfo
            {
                UserId = _guidGenerator.Create(),
                UserName = userName,
                Password = UserConstants.DefaultPassword,
                GivenName = command.TeacherName,
                PhoneNumber = command.PhoneNumber,
                TargetId = teacher.Id,
            };
            teacher.AddDomainEvent(new UserCreateEvent((Guid)_currentTenant.Id, userInfo));
            await _teacherRepository.AddAsync(teacher, cancellationToken);
            return teacher.Id;

        }
    }
}
