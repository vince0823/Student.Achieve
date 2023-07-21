using Ardalis.GuardClauses;
using AutoMapper;
using Fabricdot.Infrastructure.Queries;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.WebApi.Application.Queries.Classes;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Queries.Courses
{
    public class GetCourseDetailsQueryHandler : QueryHandler<GetCourseDetailsQuery, CourseDetailsDto>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCourseDetailsQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public override async Task<CourseDetailsDto> ExecuteAsync(GetCourseDetailsQuery query, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(query.CourseId, cancellationToken);
            Guard.Against.Null(course, nameof(course));
            var dto = _mapper.Map<CourseDetailsDto>(course);
            return dto;
        }
    }
}
