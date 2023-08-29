using Ardalis.GuardClauses;
using AutoMapper;
using Fabricdot.Infrastructure.Queries;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Specifications;
using Student.Achieve.WebApi.Application.Queries.Courses;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Queries.ExamTasks
{
    public class GetExamTaskDetailsQueryHandler : QueryHandler<GetExamTaskDetailsQuery, ExamTaskDetailsDto>
    {

        private readonly IExamTaskRepository _examTaskRepository;
        private readonly IMapper _mapper;

        public GetExamTaskDetailsQueryHandler(IExamTaskRepository examTaskRepository,
            IMapper mapper)
        {
            _examTaskRepository = examTaskRepository;
            _mapper = mapper;

        }

        public override async Task<ExamTaskDetailsDto> ExecuteAsync(GetExamTaskDetailsQuery query, CancellationToken cancellationToken)
        {
            var spec = new ExamTaskFilter(query.ExamTaskId);
            var task = await _examTaskRepository.GetBySpecAsync(spec, cancellationToken);
            Guard.Against.Null(task, nameof(task));
            var dto = _mapper.Map<ExamTaskDetailsDto>(task);
            dto.CourseIds = task.examTask_Courses.Select(c => c.CourseId).ToList();
            dto.ClassIds = task.examTask_Classes.Select(c => c.ClassId).ToList();
            return dto;
        }
    }
}
