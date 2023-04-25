using Fabricdot.Domain.Services;
using Student.Achieve.Domain.Aggregates.GradeAggregate;
using Student.Achieve.Domain.Aggregates.TeacherAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher, Guid>
    {
    }
}
