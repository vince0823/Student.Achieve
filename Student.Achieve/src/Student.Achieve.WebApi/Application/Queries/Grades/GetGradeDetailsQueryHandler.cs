using Ardalis.GuardClauses;
using AutoMapper;
using Fabricdot.Identity.Domain.Repositories;
using Fabricdot.Infrastructure.Queries;
using Student.Achieve.Domain.Aggregates.TeacherAggregate;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.WebApi.Application.Queries.Teachers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Queries.Grades
{
    public class GetGradeDetailsQueryHandler : QueryHandler<GetGradeDetailsQuery, GradeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IGradeRepository _gradeRepository;
        private readonly IUserRepository<User> _userRepository;

        public GetGradeDetailsQueryHandler(IMapper mapper, IGradeRepository gradeRepository, IUserRepository<User> userRepository)
        {
            _mapper = mapper;
            _gradeRepository = gradeRepository;
            _userRepository = userRepository;
        }

        public override async Task<GradeDetailsDto> ExecuteAsync(GetGradeDetailsQuery query, CancellationToken cancellationToken)
        {
            var grade = await _gradeRepository.GetByIdAsync(query.GradeId, cancellationToken);
            Guard.Against.Null(grade, nameof(grade));
            var detail = _mapper.Map<GradeDetailsDto>(grade);
            detail.DutyUserName = (await _userRepository.GetByIdAsync((Guid)grade.DutyUserID, cancellationToken))?.GivenName;
            return detail;
        }
    }
}
