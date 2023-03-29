using Fabricdot.Infrastructure.Data;
using System;
using System.Data;

namespace Student.Achieve.Infrastructure.Data
{
    public class DefaultSqlConnectionFactory : SqlConnectionFactory
    {
        public DefaultSqlConnectionFactory(string connectionString) : base(connectionString)
        {
        }

        protected override IDbConnection CreateConnection(string connectionString)
        {
            // Create db connection.
            throw new NotImplementedException();
        }
    }
}