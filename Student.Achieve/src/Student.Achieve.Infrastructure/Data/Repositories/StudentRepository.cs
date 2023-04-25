using Fabricdot.Infrastructure.EntityFrameworkCore;
using Student.Achieve.Domain.Aggregates.StudentAggregate;
using Student.Achieve.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Data.Repositories
{
    internal class StudentRepository : EfRepository<AppDbContext, Student.Achieve.Domain.Aggregates.StudentAggregate.Student, Guid>, IStudentRepository
    {
        public StudentRepository(IDbContextProvider<AppDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
