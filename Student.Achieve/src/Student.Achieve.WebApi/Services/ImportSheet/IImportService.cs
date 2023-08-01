using Student.Achieve.Infrastructure.Documents.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Student.Achieve.WebApi.Services.ImportSheet
{
    public interface IImportService
    {
        /// <summary>
        ///     Map CellValues to specific model
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        TModel MapTo<TModel>(CellValues values) where TModel : new();

        /// <summary>
        ///     Try read row value
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="rowValues"></param>
        /// <param name="resolve"></param>
        /// <param name="reject"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IList<ErrorInfo>> TryReadValuesAsync<TModel>(
            RowValues rowValues,
            Func<TModel, CellValues, CancellationToken, Task> resolve,
            Func<Exception, CellValues, CancellationToken, Task> reject = null,
            CancellationToken cancellationToken = default) where TModel : new();
    }
}
