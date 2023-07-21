using Fabricdot.Core.UniqueIdentifier;
using Fabricdot.Infrastructure.Commands;
using Fabricdot.MultiTenancy.Abstractions;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Shared.Exceptions;
using Student.Achieve.Domain.Specifications;
using Student.Achieve.WebApi.Application.Commands.Grades;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Courses
{
    public class CreateCourseCommandHandler : CommandHandler<CreateCourseCommand, Guid>
    {

        private readonly ICourseRepository _courseRepository;
        private readonly IGuidGenerator _guidGenerator;
        private readonly ICurrentTenant _currentTenant;
        public CreateCourseCommandHandler(ICourseRepository courseRepository, IGuidGenerator guidGenerator, ICurrentTenant currentTenant)
        {

            _courseRepository = courseRepository;
            _guidGenerator = guidGenerator;
            _currentTenant = currentTenant;
        }

        public override async Task<Guid> ExecuteAsync(CreateCourseCommand command, CancellationToken cancellationToken)
        {
            var filter = new CourseFilter(command.CourseName);
            var oldCourse = await _courseRepository.GetBySpecAsync(filter, cancellationToken);
            if (oldCourse != null)
            {
                throw new CustomException($"系统内已存在{command.CourseName}课程");
            }
            var course = new Domain.Aggregates.CourseAggregate.Course(_guidGenerator.Create(), _currentTenant.Id, command.CourseName);
            await _courseRepository.AddAsync(course, cancellationToken);
            return course.Id;

        }
    }
}
