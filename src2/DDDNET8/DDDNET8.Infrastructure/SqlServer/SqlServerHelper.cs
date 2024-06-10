using DDDNET8.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;

namespace DDDNET8.Infrastructure.SqlServer
{
    internal static class SqlServerHelper
    {
        internal readonly static string ConnectionString;

        static SqlServerHelper()
        {
            var builder = new SqlConnectionStringBuilder();

            builder.DataSource = @"localhost\SQLEXPRESS";
            builder.InitialCatalog = "DDD";
            builder.IntegratedSecurity = true;
            builder.TrustServerCertificate = true;

            ConnectionString = builder.ConnectionString;
        }

        internal static IReadOnlyList<T> Query<T>(string sql, Func<SqlDataReader, T> createEntity)
        {
            return Query<T>(sql, null, createEntity);
        }

        internal static IReadOnlyList<T> Query<T>(string sql, SqlParameter[]? parameters, Func<SqlDataReader, T> createEntity)
        {
            var result = new List<T>();

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(createEntity(reader));
                    }
                }
            }

            return result.AsReadOnly();
        }

        internal static T QuerySingle<T>(string sql, Func<SqlDataReader, T> createEntity, T nullEntity)
        {
            return QuerySingle<T>(sql, null, createEntity, nullEntity);
        }

        internal static T QuerySingle<T>(string sql, SqlParameter[]? parameters, Func<SqlDataReader, T> createEntity, T nullEntity)
        {
            var entities = Query<T>(sql, parameters, createEntity);
            return entities.Count > 0 ? entities[0] : nullEntity;
        }

        internal static void Execute(string insert, string update, SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(update, connection))
            {
                connection.Open();

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                if (command.ExecuteNonQuery() == 0)
                {
                    command.CommandText = insert;
                    command.ExecuteNonQuery();
                }
            }
        }

        internal static void Execute(string sql, SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                command.ExecuteNonQuery();
            }
        }
    }
}
