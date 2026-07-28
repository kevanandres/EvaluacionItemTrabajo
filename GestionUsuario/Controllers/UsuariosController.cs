using GestionUsuario.Repositories;
using GestionUsuario.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionUsuario.Controllers
{
    /// <summary>
    /// Obtiene todos los usuarios activos que se encuentren en la tabla Usuarios de la BDD GestionUsuario
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _usuarioServices;

        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioServices = usuarioService;
        }

        [HttpGet("activos")]
        public async Task<IActionResult> ObtenerActivos()
        {
            var usuarios = await _usuarioServices.ObtenerActivosAsync();

            return Ok(usuarios);
        }
    }
}
