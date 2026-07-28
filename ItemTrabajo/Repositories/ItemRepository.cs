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

        /// <summary>
        /// Obtiene los items a traves del SP
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ItemsTrabajo>> ObtenerTodosAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<ItemsTrabajo>(
                "kc_Items_Obtener",
                commandType: CommandType.StoredProcedure
            );
        }

        /// <summary>
        /// Obtiene la carga de los usuarios que tenga items asignados
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CargaUsuario>> ObtenerCargaUsuariosAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<CargaUsuario>(
                "kc_Items_ObtenerCargaUsuarios",
                commandType: CommandType.StoredProcedure
            );
        }

        /// <summary>
        /// Inserta el item con las parametrizaciones especificadas
        /// </summary>
        /// <param name="request"></param>
        /// <param name="usuarioAsignado"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Cambia de estado de PENDIENTE a ASIGNADO
        /// </summary>
        /// <param name="idItem"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Obtiene los pendientes por usuarios ordenados
        /// </summary>
        /// <param name="usuarioAsignado"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ItemsTrabajo>> ObtenerPendientesUsuarioAsync(string usuarioAsignado)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parametros = new
            {
                UsuarioAsignado = usuarioAsignado
            };

            return await connection.QueryAsync<ItemsTrabajo>(
                "kc_Items_ObtenerPendientesUsuario",
                parametros,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
