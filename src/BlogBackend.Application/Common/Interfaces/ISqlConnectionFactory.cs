using System.Data;

namespace BlogBackend.Application.Common.Interfaces;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}
