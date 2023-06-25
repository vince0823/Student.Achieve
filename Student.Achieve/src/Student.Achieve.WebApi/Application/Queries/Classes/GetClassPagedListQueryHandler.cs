using AutoMapper;
using Fabricdot.Identity.Domain.Repositories;
using Fabricdot.Infrastructure.Queries;
using Fabricdot.WebApi.Models;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Specifications;
using Student.Achieve.WebApi.Application.Queries.Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Queries.Classes
{
    public class GetClassPagedListQueryHandler : QueryHandler<GetClassPagedListQuery, PagedResultDto<ClassDetailsDto>>
    {
        private readonly IClassRepository _classRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly IMapper _mapper;
        public GetClassPagedListQueryHandler(IClassRepository classRepository, IUserRepository<User> userRepository, IMapper mapper)
        {
            _classRepository = classRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public override async Task<PagedResultDto<ClassDetailsDto>> ExecuteAsync(GetClassPagedListQuery query, CancellationToken cancellationToken)
        {
            var spec = new PagedClassSpec(query.GetOffset(), query.Size, query.ClassName);
            var classes = await _classRepository.ListAsync(spec, cancellationToken);
            var total = await _classRepository.CountAsync(spec, cancellationToken);
            var list = _mapper.Map<ICollection<ClassDetailsDto>>(classes);
            var users = await _userRepository.ListAsync(cancellationToken);
            list.ForEach(v =>
            {
                v.DutyUserName = users.FirstOrDefault(t => t.Id == v.DutyUserId)?.GivenName;

            });

            return new PagedResultDto<ClassDetailsDto>(list, total);
        }
    }
}
