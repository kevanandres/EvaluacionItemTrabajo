using ItemTrabajo.Clients;
using ItemTrabajo.DTOs;
using ItemTrabajo.Models;
using ItemTrabajo.Repositories;

namespace ItemTrabajo.Services
{
    public class ItemService
    {
        private readonly ItemRepository _itemRepository;
        private readonly UsuarioClient _usuarioClient;

        public ItemService(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<ItemsTrabajo>> ObtenerTodosAsync()
        {
            return await _itemRepository.ObtenerTodosAsync();
        }

        public ItemService(ItemRepository itemRepository, UsuarioClient usuarioClient)
        {
            _itemRepository = itemRepository;
            _usuarioClient = usuarioClient;
        }

        public async Task<CrearItemResponse> CrearAsync(CrearItemRequest request)
        {
            var usuarios = await _usuarioClient.ObtenerActivosAsync();

            var usuariosActivos = usuarios.ToList();

            if (!usuariosActivos.Any())
            {
                throw new Exception("No existen usuarios activos.");
            }

            var cargas = await _itemRepository.ObtenerCargaUsuariosAsync();

            var listaCarga = usuariosActivos.Select(usuario =>
            {
                var carga = cargas.FirstOrDefault(x => x.NombreUsuario == usuario.NombreUsuario);

                return new CargaUsuario
                {
                    NombreUsuario = usuario.NombreUsuario,
                    CantidadPendientes = carga?.CantidadPendientes ?? 0,
                    CantidadAltos = carga?.CantidadAltos ?? 0
                };
            }).ToList();

            var candidatos = listaCarga;

            var proximoAVencer =
                request.FechaEntrega < DateTime.Now.AddDays(3);

            if (!proximoAVencer && request.Relevancia.Equals("Alta", StringComparison.OrdinalIgnoreCase))
            {
                candidatos = listaCarga
                    .Where(x => x.CantidadAltos <= 3)
                    .ToList();
            }

            if (!candidatos.Any())
            {
                throw new Exception("No existen usuarios disponibles para la asignación.");
            }

            var usuarioSeleccionado = candidatos
                .OrderBy(x => x.CantidadPendientes)
                .ThenBy(x => x.NombreUsuario)
                .First();

            await _itemRepository.InsertarAsync(
                request,
                usuarioSeleccionado.NombreUsuario
            );

            var pendientesOrdenados =
            await _itemRepository.ObtenerPendientesUsuarioAsync(
                usuarioSeleccionado.NombreUsuario
            );

            return new CrearItemResponse
            {
                UsuarioAsignado = usuarioSeleccionado.NombreUsuario,
                PendientesOrdenados = pendientesOrdenados
            };
        }

        public async Task<bool> CompletarAsync(int idItem)
        {
            var filasAfectadas =
                await _itemRepository.CompletarAsync(idItem);

            return filasAfectadas > 0;
        }
    }
}
