﻿using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.Domain.Shared.Constants;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Users
{
    internal class LockoutUserCommandHandler : CommandHandler<LockoutUserCommand>
    {
        private readonly UserManager<User> _userManager;

        public LockoutUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public override async Task<Unit> ExecuteAsync(
            LockoutUserCommand command,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(command.UserId.ToString());
            Guard.Against.Null(user, nameof(user));

            var res = await _userManager.SetLockoutEnabledAsync(user, true);
            res.EnsureSuccess();
            var lockoutEnd = command.LockoutEnd ?? DateTimeOffset.UtcNow.AddDays(UserConstants.DefaultLockDays);
            res = await _userManager.SetLockoutEndDateAsync(user, lockoutEnd);
            res.EnsureSuccess();

            return Unit.Value;
        }
    }
}