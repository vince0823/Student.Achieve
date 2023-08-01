using System.Collections.Generic;

namespace Student.Achieve.WebApi.Services.ImportSheet
{
    public sealed class ErrorInfo//密封类
    {
        public int RowIndex { get; set; }
        public List<string> Details { get; set; }

        public ErrorInfo(int rowIndex, List<string> details)
        {
            RowIndex = rowIndex;
            Details = details;
        }


    }
}
