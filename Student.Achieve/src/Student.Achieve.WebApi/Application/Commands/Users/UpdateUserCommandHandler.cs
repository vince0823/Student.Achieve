﻿using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Users
{
    internal class UpdateUserCommandHandler : CommandHandler<UpdateUserCommand>
    {
        private readonly UserManager<User> _userManager;

        public UpdateUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public override async Task<Unit> ExecuteAsync(
            UpdateUserCommand command,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(command.UserId.ToString());
            Guard.Against.Null(user, nameof(user));

            user.GivenName = command.GivenName.Trim();
            user.Surname = command.Surname?.Trim();
            await _userManager.SetEmailAsync(user, command.Email);
            await _userManager.SetPhoneNumberAsync(user, command.PhoneNumber);
            var res = await _userManager.UpdateAsync(user);
            res.EnsureSuccess();

            return Unit.Value;
        }
    }
}