using Fabricdot.Infrastructure.EntityFrameworkCore;
using Student.Achieve.Domain.Aggregates.TeacherAggregate;
using Student.Achieve.Domain.Aggregates.TenantAggregate;
using Student.Achieve.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Data.Repositories
{
    internal class TeacherRepository : EfRepository<AppDbContext, Teacher, Guid>, ITeacherRepository
    {
        public TeacherRepository(IDbContextProvider<AppDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
