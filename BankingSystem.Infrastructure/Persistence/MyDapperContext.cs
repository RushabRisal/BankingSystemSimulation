

using BankingSystem.Infrastructure.InfraExceptionHandler;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace BankingSystem.Infrastructure.Persistence
{
    public class MyDapperContext
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;
        public MyDapperContext(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("ConnectionString") ?? throw new IncorrectConnectionStringException("The connection string is invalid or null");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
