using Fabricdot.Infrastructure.EntityFrameworkCore;
using Student.Achieve.Domain.Aggregates.GradeAggregate;
using Student.Achieve.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Data.Repositories
{
    internal class GradeRepository : EfRepository<AppDbContext, Grade, Guid>, IGradeRepository
    {
        public GradeRepository(IDbContextProvider<AppDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
