using Ardalis.GuardClauses;
using Fabricdot.Domain.Events;
using Fabricdot.Identity.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.Domain.Events;
using Student.Achieve.Domain.Specifications;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.EventHandlers
{
    public class UserUpdateEventHandler : IDomainEventHandler<UserUpdateEvent>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository<User> _userRepository;
        public UserUpdateEventHandler(UserManager<User> userManager, IUserRepository<User> userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }
        public async Task HandleAsync(UserUpdateEvent domainEvent, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetBySpecAsync(new UserFilterSpec(domainEvent.TargetId), cancellationToken);
            Guard.Against.Null(user, nameof(user));
            user.GivenName = domainEvent.GivenName.Trim();
            await _userManager.SetEmailAsync(user, domainEvent.Email);
            await _userManager.SetPhoneNumberAsync(user, domainEvent.PhoneNumber);
            var res = await _userManager.UpdateAsync(user);
            res.EnsureSuccess();
        }
    }
}
