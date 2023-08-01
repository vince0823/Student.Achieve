using Student.Achieve.Infrastructure.Documents.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Documents
{
    public class ExcelServiceOptions
    {
        public ISet<ICellValueFormatProvider> CellValueFormatProviders { get; set; } = new HashSet<ICellValueFormatProvider>();

        public TemplateOptions TemplateOptions { get; set; } = TemplateOptions.Default;
    }
}
