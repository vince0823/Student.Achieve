﻿using Fabricdot.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Student.Achieve.Infrastructure.Documents.Models;
using Student.Achieve.Infrastructure.Documents.System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;
using Ardalis.GuardClauses;

namespace Student.Achieve.WebApi.Services.ImportSheet
{
    [Dependency(ServiceLifetime.Singleton)]
    public class ImportService : IImportService
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly IDictionary<object, object> _valueMapping = new Dictionary<object, object>
        {
            {"是", true},
            {"否", false}
        };

        public ImportService(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public TModel MapTo<TModel>(CellValues values) where TModel : new()
        {
            var type = typeof(TModel);
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                 .Where(v => v.CanWrite);
            var instance = Activator.CreateInstance<TModel>();

            foreach (var property in properties)
            {
                var cellValue = values[property.Name];
                var val = cellValue?.Value;
                var propertyType = property.PropertyType;
                try
                {
                    if (val is IConvertible && propertyType != val.GetType())
                    {
                        val = Convert.ChangeType(val, propertyType);
                    }

                    if (propertyType == typeof(bool))
                        val = GetBool(val, _valueMapping);

                    if (propertyType == typeof(string))
                        val = val?.ToString();

                    property.SetValue(instance, val);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw new InvalidCellValueException($"第{cellValue.ColumnIndex + 1}列存在格式错误", e);
                }
            }

            return instance;
        }

        /// <inheritdoc />
        public async Task<IList<ErrorInfo>> TryReadValuesAsync<TModel>(
            RowValues rowValues,
            Func<TModel, CellValues, CancellationToken, Task> resolve,
            Func<Exception, CellValues, CancellationToken, Task> reject = null,
            CancellationToken cancellationToken = default) where TModel : new()
        {
            var errors = new List<ErrorInfo>();
            foreach (var values in rowValues)
                try
                {
                    var dto = MapTo<TModel>(values);
                    var isValid = dto.Validate(out var validationResults, _serviceProvider);

                    if (!isValid)
                    {
                        errors.Add(new ErrorInfo(values.RowIndex,
                            validationResults.Select(v => v.ErrorMessage).ToList()));
                        continue;
                    }

                    if (resolve != null)
                        await resolve.Invoke(dto, values, cancellationToken);
                }
                catch (Exception e)
                {
                    var error = errors.SingleOrDefault(v => v.RowIndex == values.RowIndex);
                    if (error == null)
                        errors.Add(new ErrorInfo(values.RowIndex, new List<string> { e.Message }));
                    else
                        error.Details.Add(e.Message);
                    if (reject != null)
                        await reject.Invoke(e, values, cancellationToken);
                }

            return errors;
        }

        private static bool? GetBool(object value, IDictionary<object, object> mapping)
        {
            Guard.Against.NullOrEmpty(mapping, nameof(mapping));
            if (value == null || !mapping.ContainsKey(value))
                return null;
            return mapping[value] as bool?;
        }
    }
}
