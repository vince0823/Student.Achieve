using Ardalis.GuardClauses;
using Fabricdot.Core.UniqueIdentifier;
using Fabricdot.Infrastructure.Commands;
using Fabricdot.MultiTenancy.Abstractions;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Shared.Exceptions;
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
        public CreateStudentCommandHandler(IStudentRepository studentRepository, IClassRepository classRepository, IGuidGenerator guidGenerator, ICurrentTenant currentTenant)
        {
            _studentRepository = studentRepository;
            _classRepository = classRepository;
            _guidGenerator = guidGenerator;
            _currentTenant = currentTenant;
        }

        public override async Task<Guid> ExecuteAsync(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            var selectClass = await _classRepository.GetByIdAsync(command.ClassId, cancellationToken);
            Guard.Against.Null(selectClass, nameof(selectClass),"班级不存在");
            var student = new Student.Achieve.Domain.Aggregates.StudentAggregate.Student(_guidGenerator.Create(), _currentTenant.Id, command.StudentName, command.PhoneNumber, command.StudentEmail, command.ClassId);
            await _studentRepository.AddAsync(student, cancellationToken);
            return student.Id;
        }
    }
}
