﻿using Fabricdot.Domain.Services;
using Fabricdot.Identity.Domain.Repositories;
using Student.Achieve.Domain.Specifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Aggregates.UserAggregate
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository<User> _userRepository;

        public UserService(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EnsurePhoneNumberIsUniqueAsync(
            User user,
            CancellationToken cancellationToken = default)
        {
            if (user.PhoneNumber.IsNullOrEmpty())
                return;
            var specification = new UserFilterSpec(user.Id, user.PhoneNumber!);
            if (await _userRepository.AnyAsync(specification, cancellationToken))
                throw new DuplicatedUserPhoneNumberException();
        }
    }
}