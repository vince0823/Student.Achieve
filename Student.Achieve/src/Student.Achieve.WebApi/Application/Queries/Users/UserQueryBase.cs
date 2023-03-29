using Fabricdot.Infrastructure.Queries;
using System;

namespace Student.Achieve.WebApi.Application.Queries.Users
{
    public abstract class UserQueryBase<T> : Query<T>
    {
        public Guid UserId { get; }

        protected UserQueryBase(Guid userId)
        {
            UserId = userId;
        }
    }
}