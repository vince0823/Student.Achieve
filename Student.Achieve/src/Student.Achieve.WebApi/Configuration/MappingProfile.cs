using AutoMapper;
using JetBrains.Annotations;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.WebApi.Application.Queries.Users;

namespace Student.Achieve.WebApi.Configuration
{
    /// <summary>
    ///  mapping configuration
    /// </summary>
    [UsedImplicitly]
    public class MappingProfile : Profile
    {
        //configure mapping
        public MappingProfile()
        {
            CreateMap<User, UserDetailsDto>().ForMember(v => v.Roles, opts => opts.Ignore());
        }
    }
}