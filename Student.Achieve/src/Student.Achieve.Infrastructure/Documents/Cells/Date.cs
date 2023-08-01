using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Documents.Cells
{
    public readonly struct Date
    {
        private readonly DateTime _originalTime;

        public DateTime Value { get; }

        public Date(DateTime dateTime)
        {
            _originalTime = dateTime;
            Value = dateTime.Date;
        }

        public Date Add(TimeSpan value) => new(_originalTime.Add(value));

        public string ToString([CanBeNull] string format)
        {
            return Value.ToString(format);
        }

        public static implicit operator Date(DateTime date) => new(date);
    }
}
