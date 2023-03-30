﻿using Ardalis.Specification;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using System;
using System.Linq;

namespace Student.Achieve.Domain.Specifications
{
    public sealed class UserFilterSpec : Specification<User>
    {
        public UserFilterSpec(
            Guid userId,
            string phoneNumber)
        {
            Query.Where(v => v.Id != userId && v.PhoneNumber == phoneNumber);
        }
    }
}