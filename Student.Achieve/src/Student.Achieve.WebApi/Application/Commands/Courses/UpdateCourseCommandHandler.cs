using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Shared.Exceptions;
using Student.Achieve.Domain.Specifications;
using Student.Achieve.WebApi.Application.Commands.Grades;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Courses
{
    public class UpdateCourseCommandHandler : CommandHandler<UpdateCourseCommand, Guid>
    {
        private readonly ICourseRepository _courseRepository;
        public UpdateCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public override async Task<Guid> ExecuteAsync(UpdateCourseCommand command, CancellationToken cancellationToken)
        {
            var spec = new CourseFilter(command.CourseId, command.CourseName);
            var oldCourse = await _courseRepository.GetBySpecAsync(spec, cancellationToken);
            if (oldCourse != null)
            {
                throw new CustomException($"系统内已存在{command.CourseName}课程");
            }
            var course = await _courseRepository.GetByIdAsync(command.CourseId, cancellationToken);
            Guard.Against.Null(course, nameof(course));
            course.Update(command.CourseName);
            await _courseRepository.UpdateAsync(course, cancellationToken);
            return course.Id;
        }
    }
}
