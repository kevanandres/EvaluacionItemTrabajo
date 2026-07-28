using Dapper;
using GestionUsuario.Data;
using GestionUsuario.Models;
using System.Data;

namespace GestionUsuario.Repositories
{
    public class UsuarioRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public UsuarioRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Usuario>> ObtenerActivosAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Usuario>(
                "kc_Usuarios_ObtenerActivos",
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
