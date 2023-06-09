﻿using Ardalis.GuardClauses;
using AutoMapper;
using Fabricdot.Identity.Domain.Repositories;
using Fabricdot.Infrastructure.Queries;
using Student.Achieve.Domain.Aggregates.RoleAggregate;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.WebApi.Application.Queries.Roles;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Queries.Users
{
    internal class GetUserRolesQueryHandler : QueryHandler<GetUserRolesQuery, ICollection<RoleDto>>
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IRoleRepository<Role> _roleRepository;
        private readonly IMapper _mapper;

        public GetUserRolesQueryHandler(
            IUserRepository<User> userRepository,
            IRoleRepository<Role> roleRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public override async Task<ICollection<RoleDto>> ExecuteAsync(
            GetUserRolesQuery query,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetDetailsByIdAsync(query.UserId, cancellationToken);
            Guard.Against.Null(user, nameof(user));
            var roles = await _roleRepository.ListAsync(user.Roles.Select(v => v.RoleId).ToArray());
            return _mapper.Map<ICollection<RoleDto>>(roles);
        }
    }
}