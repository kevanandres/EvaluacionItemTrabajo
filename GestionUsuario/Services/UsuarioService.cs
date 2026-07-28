using GestionUsuario.Models;
using GestionUsuario.Repositories;

namespace GestionUsuario.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> ObtenerActivosAsync()
        {
            return await _usuarioRepository.ObtenerActivosAsync();
        }
    }
}
