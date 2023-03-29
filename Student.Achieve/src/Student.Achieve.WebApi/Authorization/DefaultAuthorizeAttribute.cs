using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Student.Achieve.WebApi.Authorization
{
    public class DefaultAuthorizeAttribute : AuthorizeAttribute
    {
        public DefaultAuthorizeAttribute()
        {
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }
    }
}