using AutoMapper;
using Fabricdot.Identity.Domain.Repositories;
using Fabricdot.Infrastructure.Queries;
using Fabricdot.WebApi.Models;
using Microsoft.AspNetCore.Identity;
using Student.Achieve.Domain.Aggregates.TeacherAggregate;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Specifications;
using Student.Achieve.WebApi.Application.Queries.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Queries.Grades
{
    public class GetGradePagedListQueryHandler : QueryHandler<GetGradePagedListQuery, PagedResultDto<GradeDetailsDto>>
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly IMapper _mapper;
        public GetGradePagedListQueryHandler(IGradeRepository gradeRepository, IMapper mapper, IUserRepository<User> userRepository)
        {
            _gradeRepository = gradeRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public override async Task<PagedResultDto<GradeDetailsDto>> ExecuteAsync(GetGradePagedListQuery query, CancellationToken cancellationToken)
        {
            var spec = new PagedGradeSpec(query.GetOffset(), query.Size, query.GradeName);
            var grades = await _gradeRepository.ListAsync(spec, cancellationToken);
            var total = await _gradeRepository.CountAsync(spec, cancellationToken);

            var list = _mapper.Map<ICollection<GradeDetailsDto>>(grades);
            list.ForEach(async v =>
            {
                var grade = grades.Single(o => o.Id == v.Id);
                v.DutyUserName = (await _userRepository.GetByIdAsync((Guid)grade.DutyUserID, cancellationToken))?.GivenName;

            });
            return new PagedResultDto<GradeDetailsDto>(list, total);
        }
    }
}
