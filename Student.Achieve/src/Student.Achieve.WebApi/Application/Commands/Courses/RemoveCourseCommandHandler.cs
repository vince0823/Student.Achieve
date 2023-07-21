using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.WebApi.Application.Commands.Grades;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Courses
{
    public class RemoveCourseCommandHandler : CommandHandler<RemoveCourseCommand, Guid>
    {
        private readonly ICourseRepository _courseRepository;
        public RemoveCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public override async Task<Guid> ExecuteAsync(RemoveCourseCommand command, CancellationToken cancellationToken)
        {

            var course = await _courseRepository.GetByIdAsync(command.CourseId, cancellationToken);
            Guard.Against.Null(course, nameof(course));
            await _courseRepository.DeleteAsync(course, cancellationToken);
            return course.Id;

        }
    }
}
