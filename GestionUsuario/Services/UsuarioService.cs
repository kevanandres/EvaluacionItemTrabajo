using GestionUsuario.Models;
using GestionUsuario.Repositories;

namespace GestionUsuario.Services
{
    public class UsuarioService
    {
        /// <summary>
        /// Inicializa el servicio de usuarios y recibe el repositorio encargado de consultar los usuarios.
        /// </summary>
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Obtiene la lista de usuarios activos.
        /// </summary>
        public async Task<IEnumerable<Usuario>> ObtenerActivosAsync()
        {
            return await _usuarioRepository.ObtenerActivosAsync();
        }
    }
}
