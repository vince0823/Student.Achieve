using Ardalis.GuardClauses;
using Fabricdot.Domain.SharedKernel;
using Fabricdot.Infrastructure.Commands;
using Fabricdot.Infrastructure.Data.Filters;
using Microsoft.AspNetCore.Identity;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Infrastructure.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Authentication
{
    internal class AuthenticateCommandHandler : CommandHandler<AuthenticateCommand, JwtTokenValue>
    {
        private readonly IDataFilter _dataFilter;
        private readonly SignInManager<User> _signInManager;
        private readonly ITenantRepository _tenantRepository;
        private readonly IJwtSecurityTokenService _jwtSecurityTokenService;

        public AuthenticateCommandHandler(
            IDataFilter dataFilter,
            SignInManager<User> signInManager,
             ITenantRepository tenantRepository,
            IJwtSecurityTokenService jwtSecurityTokenService)
        {
            _dataFilter = dataFilter;
            _signInManager = signInManager;
            _tenantRepository = tenantRepository;
            _jwtSecurityTokenService = jwtSecurityTokenService;
        }

        public override async Task<JwtTokenValue> ExecuteAsync(
            AuthenticateCommand command,
            CancellationToken cancellationToken)
        {
            var user = await FindUserAsync(command);
            var signInResult = await _signInManager.PasswordSignInAsync(user, command.Password, false, true);
            if (!signInResult.Succeeded)
            {
                if (signInResult.IsNotAllowed)//confirm email or phone number
                    throw new UserNotAllowedException();

                if (signInResult.IsLockedOut)
                    throw new UserLockedOutException();

                throw new InvalidUserPasswordException();
            }

            if (!user.IsActive)
                throw new CommandException("User is inactive.");
            if (user.TenantId.HasValue)
            {
                var tenant = await _tenantRepository.GetByIdAsync(
                    user.TenantId.Value,
                    cancellationToken);
                Guard.Against.Null(tenant, nameof(tenant));
                tenant.EnsureIsEnable();
            }
            var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(user);
            return await _jwtSecurityTokenService.CreateTokenAsync(claimsPrincipal);

            async Task<User> FindUserAsync(AuthenticateCommand request)
            {
                using var scope = _dataFilter.Disable<IMultiTenant>();
                var user = await _signInManager.UserManager.FindByNameAsync(request.UserName);
                return user ?? throw new InvalidUserLoginException();
            }
        }
    }
}