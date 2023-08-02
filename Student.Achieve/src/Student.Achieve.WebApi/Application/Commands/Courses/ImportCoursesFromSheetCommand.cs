using Ardalis.GuardClauses;
using Fabricdot.Infrastructure.Commands;
using NPOI.SS.Formula.Functions;
using Student.Achieve.Infrastructure.Documents.Models;
using Student.Achieve.WebApi.Services.ImportSheet;
using System;

namespace Student.Achieve.WebApi.Application.Commands.Courses
{
    public class ImportCoursesFromSheetCommand : Command<ImportSheetResultDto>
    {
        public RowValues Rows { get; }
        public Guid TenantId { get; set; }

        public ImportCoursesFromSheetCommand(RowValues rows, Guid tenantId)
        {
            Rows = Guard.Against.Null(rows, nameof(rows));
            TenantId = Guard.Against.Null(tenantId, nameof(tenantId));
        }
    }
}
