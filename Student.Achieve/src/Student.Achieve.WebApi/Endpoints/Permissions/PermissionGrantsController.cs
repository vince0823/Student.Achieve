using Fabricdot.WebApi.Endpoint;
using Student.Achieve.WebApi.Authorization;

namespace Student.Achieve.WebApi.Endpoints.Permissions
{
    [DefaultAuthorize]
    public abstract class PermissionGrantsController : EndPointBase
    {
        protected abstract string GrantType { get; }
    }
}