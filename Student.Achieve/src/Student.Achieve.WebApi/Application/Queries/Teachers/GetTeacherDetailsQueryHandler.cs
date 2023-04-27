using AutoMapper;
using Fabricdot.Infrastructure.Queries;
using Student.Achieve.Domain.Aggregates.RoleAggregate;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.WebApi.Application.Queries.Roles;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Queries.Teachers
{
    public class GetTeacherDetailsQueryHandler : QueryHandler<GetTeacherDetailsQuery, TeacherDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ITeacherRepository _teacherRepository;
        public GetTeacherDetailsQueryHandler(IMapper mapper, ITeacherRepository teacherRepository)
        {
            _mapper = mapper;
            _teacherRepository = teacherRepository;
        }

        public override async Task<TeacherDetailsDto> ExecuteAsync(GetTeacherDetailsQuery query, CancellationToken cancellationToken)
        {
            var teacher = await _teacherRepository.GetByIdAsync(query.TeacherId, cancellationToken);
            return _mapper.Map<TeacherDetailsDto>(teacher);

        }
    }
}
