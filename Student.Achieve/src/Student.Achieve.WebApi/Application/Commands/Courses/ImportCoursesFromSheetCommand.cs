using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using NPOI.SS.Formula.Functions;
using Student.Achieve.Infrastructure.Documents.Models;
using Student.Achieve.WebApi.Services.ImportSheet;

namespace Student.Achieve.WebApi.Application.Commands.Courses
{
    public class ImportCoursesFromSheetCommand : Command<ImportSheetResultDto>
    {
        public RowValues Rows { get; }

    public ImportCoursesFromSheetCommand(RowValues rows)
    {
        Rows = Guard.Against.Null(rows, nameof(rows));
    }
}
}
