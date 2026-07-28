using ItemTrabajo.DTOs;
using ItemTrabajo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItemTrabajo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemsController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var items = await _itemService.ObtenerTodosAsync();

            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearItemRequest request)
        {
            var usuarioAsignado = await _itemService.CrearAsync(request);

            return Ok(new
            {
                mensaje = "Ítem creado correctamente",
                usuarioAsignado
            });
        }

        [HttpPut("{idItem}/completar")]
        public async Task<IActionResult> Completar(int idItem)
        {
            var completado = await _itemService.CompletarAsync(idItem);

            if (!completado)
            {
                return NotFound(new
                {
                    mensaje = "El ítem no existe o ya fue completado."
                });
            }

            return Ok(new
            {
                mensaje = "Ítem completado correctamente."
            });
        }
    }
}
