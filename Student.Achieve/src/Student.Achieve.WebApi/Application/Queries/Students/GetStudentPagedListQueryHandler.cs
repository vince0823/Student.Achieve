using AutoMapper;
using Fabricdot.Infrastructure.Queries;
using Fabricdot.WebApi.Models;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Specifications;
using Student.Achieve.WebApi.Application.Queries.Classes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Queries.Students
{
    public class GetStudentPagedListQueryHandler : QueryHandler<GetStudentPagedListQuery, PagedResultDto<StudentDetailsDto>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentPagedListQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }


        public override async Task<PagedResultDto<StudentDetailsDto>> ExecuteAsync(GetStudentPagedListQuery query, CancellationToken cancellationToken)
        {
            var spec = new PagedStudentSpec(query.GetOffset(), query.Size, query.StudentName);
            var students = await _studentRepository.ListAsync(spec, cancellationToken);
            var total = await _studentRepository.CountAsync(spec, cancellationToken);
            var list = _mapper.Map<ICollection<StudentDetailsDto>>(students);
            list.ForEach(v =>
            {
                v.ClassName = v.Class.ClassName;
            });
            return new PagedResultDto<StudentDetailsDto>(list, total);
        }
    }
}
