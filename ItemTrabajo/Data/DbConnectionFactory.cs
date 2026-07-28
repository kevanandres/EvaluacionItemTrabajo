using Microsoft.Data.SqlClient;
using System.Data;

namespace ItemTrabajo.Data
{
    public class DbConnectionFactory
    {
        private readonly string _connectionString;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServer") ?? throw new InvalidOperationException("Cadena de conexion no encontrada");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
