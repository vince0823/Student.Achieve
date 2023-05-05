﻿using Ardalis.Specification;
using Student.Achieve.Domain.Aggregates.ClassAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Specifications
{
    public class ClassFilterSpec : Specification<Class>
    {
        public ClassFilterSpec(Guid gradeId)
        {
            Query.AsNoTracking().Where(v => v.GradeId == gradeId);
        }
    }
}