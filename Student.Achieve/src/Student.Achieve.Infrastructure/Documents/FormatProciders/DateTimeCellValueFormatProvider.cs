using Student.Achieve.Infrastructure.Documents.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Documents.FormatProciders
{
    internal class DateTimeCellValueFormatProvider : CellValueFormatProviderBase
    {
        /// <inheritdoc />
        public override Type Type => typeof(DateTime);

        /// <inheritdoc />
        public override object Format(object value)
        {
            if (!(value is DateTime dateTime))
                return value;
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
