using Fabricdot.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Student.Achieve.Infrastructure.Documents.Abstractions;
using Student.Achieve.Infrastructure.Documents.FormatProciders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Achieve.Infrastructure.Documents
{
    [ServiceContract(typeof(IConfigureOptions<ExcelServiceOptions>))]
    [Dependency(ServiceLifetime.Singleton)]
    public class ConfigureExcelServiceOptions : IConfigureOptions<ExcelServiceOptions>
    {
        public void Configure(ExcelServiceOptions options)
        {
            options.CellValueFormatProviders ??= new HashSet<ICellValueFormatProvider>();
            var valueFormatProviders = options.CellValueFormatProviders;
            valueFormatProviders.Add(new DefaultCellValueFormatProvider());
            valueFormatProviders.Add(new DateTimeCellValueFormatProvider());
            valueFormatProviders.Add(new DateCellValueFormatProvider());
            valueFormatProviders.Add(new BooleanCellValueFormatProvider());

            options.TemplateOptions ??= TemplateOptions.Default;
        }
    }
}
