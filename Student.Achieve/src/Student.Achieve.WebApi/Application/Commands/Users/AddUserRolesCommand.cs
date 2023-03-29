using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using System;

namespace Student.Achieve.WebApi.Application.Commands.Users
{
    public class AddUserRolesCommand : Command
    {
        public Guid UserId { get; }

        public string[] RoleNames { get; }

        public AddUserRolesCommand(
            Guid userId,
            string[] roleNames)
        {
            Guard.Against.NullOrEmpty(roleNames, nameof(roleNames));

            UserId = userId;
            RoleNames = roleNames;
        }
    }
}