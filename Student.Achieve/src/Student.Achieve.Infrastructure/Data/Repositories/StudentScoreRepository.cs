using Fabricdot.Infrastructure.EntityFrameworkCore;
using Student.Achieve.Domain.Aggregates.ExamTaskAggregate;
using Student.Achieve.Domain.Aggregates.StudentScoreAggregate;
using Student.Achieve.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Data.Repositories
{
    internal class StudentScoreRepository : EfRepository<AppDbContext, StudentScore, Guid>, IStudentScoreRepository
    {
        public StudentScoreRepository(IDbContextProvider<AppDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}

