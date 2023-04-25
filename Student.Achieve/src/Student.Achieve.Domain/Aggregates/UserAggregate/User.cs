using Ardalis.GuardClauses;
using Fabricdot.Domain.SharedKernel;
using Fabricdot.Identity.Domain.Entities.UserAggregate;
using System;

namespace Student.Achieve.Domain.Aggregates.UserAggregate
{
    public class User : IdentityUser, IMultiTenant
    {
        public Guid? TenantId { get; private set; }

        public UserType UserType { get; private set; } = UserType.Teacher;

        public Guid? TargetId { get; private set; }
        public User(
            Guid userId,
            string userName,
            string givenName,
            string surname = null,
            string email = null) : base(userId, userName)
        {
            GivenName = givenName;
            Surname = surname;
            Email = email?.Trim();
            EmailConfirmed = false;
            Enable();
        }
        public User(
           Guid tenantId,
           Guid userId,
           string userName,
           string givenName,
           string surname = null,
           string email = null) : this(
               userId,
               userName,
               givenName,
               surname,
               email)
        {
            TenantId = tenantId;
        }

        public User(
              Guid tenantId,
          Guid userId,
          string userName,
          string givenName,
           UserType userType,
           Guid? targetId,
          string surname = null,
          string email = null
         ) : base(userId, userName)
        {
            TenantId = tenantId;
            GivenName = givenName;
            Surname = surname;
            Email = email?.Trim();
            EmailConfirmed = false;
            Enable();
            UserType = userType;
            TargetId = targetId;
        }
        private User()
        {
        }
        public void SetPhoneNumber(string phoneNumber)
        {
            PhoneNumber = Guard.Against.NullOrEmpty(phoneNumber.Trim(), nameof(phoneNumber));
            PhoneNumberConfirmed = false;
        }
    }
}