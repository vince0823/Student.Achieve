using Fabricdot.Domain.Events;
using Fabricdot.Domain.SharedKernel;
using Fabricdot.Infrastructure.Data.Filters;
using Microsoft.AspNetCore.Identity;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.Domain.Events;
using System.Threading.Tasks;
using System.Threading;

namespace Student.Achieve.WebApi.Application.EventHandlers
{
    public class TenantCreatedEventHandler : IDomainEventHandler<TenantCreatedEvent>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IDataFilter _dataFilter;

        public TenantCreatedEventHandler(
            UserManager<User> userManager,
            IUserService userService,
            IDataFilter dataFilter)
        {
            _userManager = userManager;
            _userService = userService;
            _dataFilter = dataFilter;
        }

        public async Task HandleAsync(
            TenantCreatedEvent domainEvent,
            CancellationToken cancellationToken)
        {
            var tenantOwner = domainEvent.TenantOwner;
            if (tenantOwner == null)
                return;

            using var scope = _dataFilter.Disable<IMultiTenant>();
            var user = new User(
                domainEvent.TenantId,
                tenantOwner.UserId,
                tenantOwner.UserName,
                tenantOwner.GivenName,
                tenantOwner.Surname);
            user.SetPhoneNumber(tenantOwner.PhoneNumber);

            await _userService.EnsurePhoneNumberIsUniqueAsync(
                user,
                cancellationToken);
            var res = await _userManager.CreateAsync(
                user,
                tenantOwner.Password);
            res.EnsureSuccess();
        }
    }
}
