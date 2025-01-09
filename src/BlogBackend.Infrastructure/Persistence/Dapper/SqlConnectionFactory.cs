using System.Data;
using BlogBackend.Application.Common.Interfaces;
using Npgsql;

namespace BlogBackend.Infrastructure.Persistence.Dapper;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        return connection;
    }
}
