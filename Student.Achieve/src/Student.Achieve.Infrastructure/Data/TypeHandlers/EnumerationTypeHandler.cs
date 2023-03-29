using Dapper;
using Fabricdot.Domain.ValueObjects;
using System.Data;

namespace Student.Achieve.Infrastructure.Data.TypeHandlers
{
    internal class EnumerationTypeHandler<T> : SqlMapper.TypeHandler<T> where T : Enumeration
    {
        /// <inheritdoc />
        public override void SetValue(IDbDataParameter parameter, T value)
        {
            parameter.Value = value.Value;
            parameter.DbType = DbType.Int32;
        }

        /// <inheritdoc />
        public override T Parse(object value)
        {
            return Enumeration.FromValue<T>((int)value);
        }
    }
}