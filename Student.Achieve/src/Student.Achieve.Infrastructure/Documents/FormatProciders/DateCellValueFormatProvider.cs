using Student.Achieve.Infrastructure.Documents.Abstractions;
using Student.Achieve.Infrastructure.Documents.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Documents.FormatProciders
{
    internal class DateCellValueFormatProvider : CellValueFormatProviderBase
    {
        /// <inheritdoc />
        public override Type Type => typeof(Date);

        /// <inheritdoc />
        public override object Format(object value)
        {
            if (!(value is Date date))
                return value;
            return date.ToString("yyyy-MM-dd");
        }
    }
}
