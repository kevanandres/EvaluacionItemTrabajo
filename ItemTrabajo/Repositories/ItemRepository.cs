using Dapper;
using ItemTrabajo.Data;
using ItemTrabajo.DTOs;
using ItemTrabajo.Models;
using System.Data;

namespace ItemTrabajo.Repositories
{
    public class ItemRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public ItemRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<ItemsTrabajo>> ObtenerTodosAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<ItemsTrabajo>(
                "kc_Items_Obtener",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<CargaUsuario>> ObtenerCargaUsuariosAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<CargaUsuario>(
                "kc_Items_ObtenerCargaUsuarios",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task InsertarAsync(CrearItemRequest request, string usuarioAsignado)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parametros = new
            {
                request.Titulo,
                request.FechaEntrega,
                request.Relevancia,
                UsuarioAsignado = usuarioAsignado
            };

            await connection.ExecuteAsync(
                "kc_Items_Insertar",
                parametros,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> CompletarAsync(int idItem)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parametros = new
            {
                IdItem = idItem
            };

            return await connection.QuerySingleAsync<int>(
                "kc_Items_Completar",
                parametros,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
