using Fabricdot.Infrastructure.Commands;
using System;

namespace Student.Achieve.WebApi.Application.Commands.Users
{
    public class RemoveUserCommand : Command
    {
        public Guid UserId { get; }

        public RemoveUserCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}