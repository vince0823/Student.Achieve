using Fabricdot.Domain.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Aggregates.UserAggregate
{
    /// <summary>
    ///     User domain service
    /// </summary>
    public interface IUserService : IDomainService
    {
        Task EnsurePhoneNumberIsUniqueAsync(
            User user,
            CancellationToken cancellationToken = default);
    }
}