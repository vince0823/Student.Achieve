using Ardalis.Specification;
using Fabricdot.Domain.Events;
using Fabricdot.Domain.Services;
using Fabricdot.Domain.SharedKernel;
using Fabricdot.Identity.Domain.Repositories;
using Fabricdot.Infrastructure.Data.Filters;
using Fabricdot.MultiTenancy.Abstractions;
using Fabricdot.PermissionGranting;
using Microsoft.AspNetCore.Identity;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.Domain.Events;
using Student.Achieve.Domain.Specifications;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.EventHandlers
{
    public class UserCreateEventHandler : IDomainEventHandler<UserCreateEvent>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IDataFilter _dataFilter;
        private readonly ICurrentTenant _currentTenant;
        private readonly IUserRepository<User> _userRepository;
        public UserCreateEventHandler(
            UserManager<User> userManager,
            IUserService userService,
            IDataFilter dataFilter,
             ICurrentTenant currentTenant,
                IUserRepository<User> userRepository
            )
        {
            _userManager = userManager;
            _userService = userService;
            _dataFilter = dataFilter;
            _currentTenant = currentTenant;
            _userRepository = userRepository;
        }
        public async Task HandleAsync(UserCreateEvent domainEvent, CancellationToken cancellationToken)
        {
            var userInfo = domainEvent.UserInfo;
            if (userInfo == null)
            {
                return;
            }
            using var scope = _dataFilter.Disable<IMultiTenant>();
            var user = new User(
                domainEvent.TenantId,
                userInfo.UserId,
                userInfo.UserName,
                userInfo.GivenName,

               UserType.Teacher,
               userInfo.TargetId,
               "",
               userInfo.Email);
            user.SetPhoneNumber(userInfo.PhoneNumber);


            var spec = new UserFilterSpec(userInfo.PhoneNumber);
            if (await _userRepository.AnyAsync(spec, cancellationToken))
            {
                var oldUser = await _userRepository.GetBySpecAsync(spec, cancellationToken);
                oldUser.GivenName = userInfo.GivenName.Trim();
                await _userManager.SetEmailAsync(oldUser, userInfo.Email);
                oldUser.ChangeTargetId(userInfo.TargetId);
                var res = await _userManager.UpdateAsync(user);
                res.EnsureSuccess();

            }
            else
            {
                await _userService.EnsurePhoneNumberIsUniqueAsync(
              user,
              cancellationToken);
                var res = await _userManager.CreateAsync(
                    user,
                    userInfo.Password);
                res.EnsureSuccess();
            }


        }
    }
}
