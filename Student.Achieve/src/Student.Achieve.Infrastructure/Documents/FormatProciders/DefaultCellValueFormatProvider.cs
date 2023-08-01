using Student.Achieve.Infrastructure.Documents.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Documents.FormatProciders
{
    internal class DefaultCellValueFormatProvider : CellValueFormatProviderBase
    {
        /// <inheritdoc />
        public override Type Type => typeof(object);

        /// <inheritdoc />
        public override object Format(object value) => value;
    }
}
