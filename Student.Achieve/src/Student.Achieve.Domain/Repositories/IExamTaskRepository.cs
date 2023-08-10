using Fabricdot.Domain.Services;
using Student.Achieve.Domain.Aggregates.ClassAggregate;
using Student.Achieve.Domain.Aggregates.ExamTaskAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Repositories
{
    public interface IExamTaskRepository : IRepository<ExamTask, Guid>
    {
    }
}
