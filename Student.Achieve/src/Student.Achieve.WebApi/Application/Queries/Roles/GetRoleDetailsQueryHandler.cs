using AutoMapper;
using Fabricdot.Identity.Domain.Repositories;
using Fabricdot.Infrastructure.Queries;
using Student.Achieve.Domain.Aggregates.RoleAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Queries.Roles
{
    internal class GetRoleDetailsQueryHandler : QueryHandler<GetRoleDetailsQuery, RoleDetailsDto>
    {
        private readonly IRoleRepository<Role> _roleRepository;
        private readonly IMapper _mapper;

        public GetRoleDetailsQueryHandler(
            IRoleRepository<Role> roleRepository,
            IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public override async Task<RoleDetailsDto> ExecuteAsync(
            GetRoleDetailsQuery query,
            CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetDetailsByIdAsync(query.RoleId, cancellationToken);
            return _mapper.Map<RoleDetailsDto>(role);
        }
    }
}