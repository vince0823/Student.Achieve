using Student.Achieve.Infrastructure.Documents.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Documents.FormatProciders
{
    internal class BooleanCellValueFormatProvider : CellValueFormatProviderBase
    {
        /// <inheritdoc />
        public override Type Type => typeof(bool);

        /// <inheritdoc />
        public override object Format(object value)
        {
            if (!(value is bool boolValue))
                return value;
            return boolValue ? "是" : "否";
        }
    }
}
