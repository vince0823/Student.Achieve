using Fabricdot.Domain.Events;
using Fabricdot.Domain.SharedKernel;
using Fabricdot.Infrastructure.Data.Filters;
using Fabricdot.MultiTenancy.Abstractions;
using Fabricdot.PermissionGranting;
using Microsoft.AspNetCore.Identity;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.Domain.Events;
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
        public UserCreateEventHandler(
            UserManager<User> userManager,
            IUserService userService,
            IDataFilter dataFilter,
             ICurrentTenant currentTenant
            )
        {
            _userManager = userManager;
            _userService = userService;
            _dataFilter = dataFilter;
            _currentTenant = currentTenant;
        }
        public async Task HandleAsync(UserCreateEvent domainEvent, CancellationToken cancellationToken)
        {
            var userInfo=domainEvent.UserInfo;
            if (userInfo==null)
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
               userInfo.TargetId);
            user.SetPhoneNumber(userInfo.PhoneNumber);

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
