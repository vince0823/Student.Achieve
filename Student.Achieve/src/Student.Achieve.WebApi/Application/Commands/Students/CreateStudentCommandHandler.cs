using Ardalis.GuardClauses;
using Fabricdot.Core.UniqueIdentifier;
using Fabricdot.Infrastructure.Commands;
using Fabricdot.MultiTenancy.Abstractions;
using Student.Achieve.Domain.Aggregates.TeacherAggregate;
using Student.Achieve.Domain.Events;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Shared.Constants;
using Student.Achieve.Domain.Shared.Exceptions;
using Student.Achieve.Infrastructure.International.Converters;
using Student.Achieve.WebApi.Application.Commands.Classes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Students
{
    public class CreateStudentCommandHandler : CommandHandler<CreateStudentCommand, Guid>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        private readonly IGuidGenerator _guidGenerator;
        private readonly ICurrentTenant _currentTenant;
        private readonly IPinyinConverter _pinyinConverter;
        public CreateStudentCommandHandler(IStudentRepository studentRepository, IClassRepository classRepository, IGuidGenerator guidGenerator, ICurrentTenant currentTenant, IPinyinConverter pinyinConverter)
        {
            _studentRepository = studentRepository;
            _classRepository = classRepository;
            _guidGenerator = guidGenerator;
            _currentTenant = currentTenant;
            _pinyinConverter = pinyinConverter;
        }

        public override async Task<Guid> ExecuteAsync(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            var selectClass = await _classRepository.GetByIdAsync(command.ClassId, cancellationToken);
            Guard.Against.Null(selectClass, nameof(selectClass), "班级不存在");
            var student = new Student.Achieve.Domain.Aggregates.StudentAggregate.Student(_guidGenerator.Create(), _currentTenant.Id, command.StudentName, command.PhoneNumber, command.StudentEmail, command.ClassId);
            var userName = _pinyinConverter.ToPinyin(command.StudentName).ToLowerInvariant();
            // 创建用户 领域事件
            var userInfo = new UserInfo
            {
                UserId = _guidGenerator.Create(),
                UserName = userName,
                Password = UserConstants.DefaultPassword,
                GivenName = command.StudentName,
                Email = command.StudentEmail,
                PhoneNumber = command.PhoneNumber,
                TargetId = student.Id,
            };
            student.AddDomainEvent(new UserCreateEvent((Guid)_currentTenant.Id, userInfo));
            await _studentRepository.AddAsync(student, cancellationToken);
            return student.Id;
        }
    }
}
