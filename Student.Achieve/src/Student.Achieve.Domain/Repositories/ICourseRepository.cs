using Fabricdot.Domain.Services;
using Student.Achieve.Domain.Aggregates.ClassAggregate;
using Student.Achieve.Domain.Aggregates.CourseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Repositories
{
    public interface ICourseRepository : IRepository<Course, Guid>
    {
    }
}
