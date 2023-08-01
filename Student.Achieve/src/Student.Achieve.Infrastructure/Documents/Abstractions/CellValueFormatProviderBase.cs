using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Documents.Abstractions
{
    public abstract class CellValueFormatProviderBase : ICellValueFormatProvider
    {
        /// <inheritdoc />
        public abstract Type Type { get; }

        /// <inheritdoc />
        public abstract object Format(object value);

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            var v = obj as ICellValueFormatProvider;
            return Type == v?.Type;
        }
    }
}
