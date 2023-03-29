using Fabricdot.Core.Modularity;
using Fabricdot.Domain;
using Fabricdot.Identity.Domain;
using Student.Achieve.Domain.Shared;

namespace Student.Achieve.Domain
{
    [Requires(typeof(StudentAchieveDomainSharedModule))]
    [Requires(typeof(FabricdotIdentityDomainModule))]
    [Requires(typeof(FabricdotDomainModule))]
    [Exports]
    public class StudentAchieveDomainModule : ModuleBase
    {
    }
}