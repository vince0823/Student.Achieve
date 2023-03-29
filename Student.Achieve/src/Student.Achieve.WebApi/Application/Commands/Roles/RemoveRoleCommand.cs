using Fabricdot.Infrastructure.Commands;
using System;

namespace Student.Achieve.WebApi.Application.Commands.Roles
{
    public class RemoveRoleCommand : Command
    {
        public Guid RoleId { get; }

        public RemoveRoleCommand(Guid roleId)
        {
            RoleId = roleId;
        }
    }
}