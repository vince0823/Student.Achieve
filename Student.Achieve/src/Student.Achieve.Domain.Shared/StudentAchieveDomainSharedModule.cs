using Fabricdot.Core.Modularity;
using Fabricdot.Domain;

namespace Student.Achieve.Domain.Shared
{
    [Requires(typeof(FabricdotDomainModule))]
    [Exports]
    public class StudentAchieveDomainSharedModule : ModuleBase
    {
    }
}