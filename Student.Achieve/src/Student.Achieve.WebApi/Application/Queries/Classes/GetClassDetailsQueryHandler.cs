using Ardalis.GuardClauses;
using AutoMapper;
using Fabricdot.Identity.Domain.Repositories;
using Fabricdot.Infrastructure.Queries;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Specifications;
using Student.Achieve.WebApi.Application.Queries.Grades;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Queries.Classes
{
    public class GetClassDetailsQueryHandler : QueryHandler<GetClassDetailsQuery, ClassDetailsDto>
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository<User> _userRepository;

        public GetClassDetailsQueryHandler(IClassRepository classRepository, IMapper mapper, IUserRepository<User> userRepository)
        {
            _classRepository = classRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public override async Task<ClassDetailsDto> ExecuteAsync(GetClassDetailsQuery query, CancellationToken cancellationToken)
        {
            var spec = new ClassDetailSpec(query.ClassId);
            var selectClass = await _classRepository.GetBySpecAsync(spec, cancellationToken);
            Guard.Against.Null(selectClass, nameof(selectClass));
            var detail = _mapper.Map<ClassDetailsDto>(selectClass);
            detail.DutyUserName = (await _userRepository.GetByIdAsync((Guid)selectClass.DutyUserId, cancellationToken))?.GivenName;
            detail.GradeName = selectClass.Grade.GradeName;
            return detail;

        }
    }
}
