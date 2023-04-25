using Fabricdot.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Domain.Aggregates.UserAggregate
{
    /// <summary>
    /// 用户类型
    /// </summary>
    public sealed class UserType : Enumeration
    {

        public static readonly UserType Teacher = new(1, nameof(Teacher).ToLowerInvariant());

        public static readonly UserType Student = new(2, nameof(Student).ToLowerInvariant());



        private UserType(
            int value,
            string name) : base(value, name)
        {
        }
    }
}
