using Fabricdot.Infrastructure.EntityFrameworkCore;
using Student.Achieve.Domain.Aggregates.ClassAggregate;
using Student.Achieve.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Data.Repositories
{
    internal class ClassRepository : EfRepository<AppDbContext, Class, Guid>, IClassRepository
    {
        public ClassRepository(IDbContextProvider<AppDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
