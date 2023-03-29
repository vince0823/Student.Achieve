using Ardalis.Specification;
using Student.Achieve.Domain.Aggregates.RoleAggregate;
using System.Linq;

namespace Student.Achieve.Domain.Specifications
{
    public sealed class RoleFilterSpec : Specification<Role>
    {
        public RoleFilterSpec(bool isDefault)
        {
            Query.Where(v => v.IsDefault == isDefault);
        }
    }
}