using Ardalis.GuardClauses;
using AutoMapper;
using Fabricdot.Infrastructure.Queries;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Specifications;
using Student.Achieve.WebApi.Application.Queries.Classes;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Queries.Students
{
    public class GetStudentDetailsQueryHandler : QueryHandler<GetStudentDetailsQuery, StudentDetailsDto>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;
        public GetStudentDetailsQueryHandler(IStudentRepository studentRepository, IClassRepository classRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _classRepository = classRepository;
            _mapper = mapper;
        }
        public override async Task<StudentDetailsDto> ExecuteAsync(GetStudentDetailsQuery query, CancellationToken cancellationToken)
        {
            var spec = new StudentSpec(query.StudentId);
            var selectStudent = await _studentRepository.GetBySpecAsync(spec, cancellationToken);
            Guard.Against.Null(selectStudent, nameof(selectStudent));
            var detail = _mapper.Map<StudentDetailsDto>(selectStudent);
            return detail;
        }
    }
}
