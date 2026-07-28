using Dapper;
using GestionUsuario.Data;
using GestionUsuario.Models;
using System.Data;

namespace GestionUsuario.Repositories
{
    /// <summary>
    /// Entabla las conexiones con el SP de la BDD correcspondiente
    /// </summary>
    public class UsuarioRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public UsuarioRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>
        /// Obtiene los usuarios activos
        /// </summary>
        /// <returns></returns>
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
